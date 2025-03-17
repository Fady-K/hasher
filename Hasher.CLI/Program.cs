using System;
using System.IO;
using System.Reflection;
using System.CommandLine;
using System.Threading.Tasks;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using System.Collections.Generic;
using Hasher.Core.HashingService;
using Hasher.Core.HashingService.Hashers;

namespace Hasher.CLI
{
	public class Program
	{
		static async Task Main(string[] args)
		{
			// Define the root command
			var rootCommand = new RootCommand("Hasher CLI: A command-line tool for hashing files and passwords.");

			// Global --version option
			var versionOption = new Option<bool>(
				new[] { "--version", "-v" },
				$"{Assembly.GetExecutingAssembly().GetName().Version}"
			);
			rootCommand.AddOption(versionOption);

			// Subcommand: hash-file
			var hashFileCommand = new Command("hash-file", "Hash one or more files using the specified algorithm.");
			var filePathsArgument = new Argument<string[]>("files", "The paths to the files to hash.");
			hashFileCommand.AddArgument(filePathsArgument);
			var fileAlgorithmOption = new Option<HashingAlgorithm>(
				new[] { "--algorithm", "-a" },
				() => HashingAlgorithm.SHA256,
				"The hashing algorithm to use (e.g., MD5, SHA1, SHA256, SHA512, Argon2)"
			);
			hashFileCommand.AddOption(fileAlgorithmOption);
			var outputOption = new Option<string>(
				new[] { "--output", "-o" },
				"The file to save the hash(es) to"
			);
			hashFileCommand.AddOption(outputOption);
			hashFileCommand.SetHandler(
				(files, algorithm, output) => HandleHashFile(files, algorithm, output),
				filePathsArgument, fileAlgorithmOption, outputOption
			);

			// Subcommand: hash-password
			var hashPasswordCommand = new Command("hash-password", "Hash a password using the specified algorithm.");
			var passwordAlgorithmOption = new Option<HashingAlgorithm>(
				new[] { "--algorithm", "-a" },
				() => HashingAlgorithm.Argon2,
				"The hashing algorithm to use (e.g., MD5, SHA1, SHA256, SHA512, Argon2)"
			);
			hashPasswordCommand.AddOption(passwordAlgorithmOption);
			hashPasswordCommand.SetHandler(
				(algorithm) => HandleHashPassword(algorithm),
				passwordAlgorithmOption
			);

			// Add subcommands to root
			rootCommand.AddCommand(hashFileCommand);
			rootCommand.AddCommand(hashPasswordCommand);

			// Build the parser with middleware
			var parser = new CommandLineBuilder(rootCommand)
				.UseHelp()
				.UseParseErrorReporting()
				.UseSuggestDirective()
				.UseTypoCorrections()
				.UseParseDirective()
				.AddMiddleware(async (context, next) =>
				{
					if (context.ParseResult.GetValueForOption(versionOption))
					{
						Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Version.ToString());
						return;
					}
					await next(context);
				})
				.Build();

			// Invoke the parser
			await parser.InvokeAsync(args);
		}

		// Handler for hash-file
		private static void HandleHashFile(string[] files, HashingAlgorithm algorithm, string output)
		{
			var hasher = new FileHasher(algorithm);
			var results = new List<(string file, string hash)>();
			var errors = new List<(string file, string error)>();

			foreach (var file in files)
			{
				try
				{
					var hashResult = hasher.Hash(file);
					string hashHex = BitConverter.ToString(hashResult.Hash);
					results.Add((file, hashHex));
				}
				catch (Exception ex)
				{
					errors.Add((file, ex.Message));
				}
			}

			// Output results
			if (output != null)
			{
				using (var writer = new StreamWriter(output))
				{
					foreach (var (file, hash) in results)
					{
						writer.WriteLine($"{file}: {hash}");
					}
				}
			}
			else
			{
				foreach (var (file, hash) in results)
				{
					Console.WriteLine($"{file}: {hash}");
				}
			}

			// Report errors
			foreach (var (file, error) in errors)
			{
				Console.Error.WriteLine($"Error hashing {file}: {error}");
			}
		}

		// Handler for hash-password
		private static void HandleHashPassword(HashingAlgorithm algorithm)
		{
			Console.Write("Enter password: ");
			string password = ReadPassword();
			var hasher = new PasswordHasher(algorithm);
			string hash = hasher.Hash(password);
			Console.WriteLine(hash);
		}

		// Securely read password without echoing
		private static string ReadPassword()
		{
			string password = "";
			ConsoleKeyInfo key;
			do
			{
				key = Console.ReadKey(intercept: true);

				if (key.Key == ConsoleKey.Backspace)
				{
					// Handle backspace: remove last character and erase asterisk
					if (password.Length > 0)
					{
						password = password.Remove(password.Length - 1);
						Console.Write("\b \b"); // Erase the last asterisk
					}
				}
				else if (key.Key != ConsoleKey.Enter)
				{
					// Append the character and display an asterisk
					password += key.KeyChar;
					Console.Write("*");
				}
			} while (key.Key != ConsoleKey.Enter);

			Console.WriteLine();
			return password;
		}
	}
}