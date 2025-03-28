# Hasher CLI Design and Implementation

**Table of Contents**

- [CLI Design Overview](#cli-design-overview)
- [Commands and Options](#commands-and-options)
  - [Root Command: `hasher`](#root-command-hasher)
  - [Subcommand: `hash-file`](#subcommand-hash-file)
  - [Subcommand: `hash-password`](#subcommand-hash-password)
- [Implementation Details](#implementation-details)
  - [Secure Password Input](#secure-password-input)
  - [Output Formatting](#output-formatting)
  - [Error Handling](#error-handling)
  - [Middleware](#middleware)
- [Code Implementation](#code-implementation)
- [Usage Examples](#usage-examples)

---

This document outlines the design and implementation of the Command-Line Interface (CLI) for the Hasher project using the `System.CommandLine` library in C#. The CLI leverages the hashing capabilities provided by the `Hasher.Core` library to hash files and passwords securely and efficiently.

## CLI Design Overview

The CLI is named `hasher` and serves as a tool for hashing files and passwords using algorithms such as MD5, SHA1, SHA256, SHA512, and Argon2. The design includes:

- **Root Command**: `hasher` � The entry point of the CLI.
- **Global Option**: `--version` / `-v` � Displays the application version.
- **Subcommands**:
  - `hash-file` � Hashes one or more files.
  - `hash-password` � Hashes a password entered securely via a prompt.

The CLI is built using the following namespaces:
- `System.CommandLine`
- `System.CommandLine.Builder`
- `System.CommandLine.Parsing`
- `System.Threading.Tasks`

## Commands and Options

### Root Command: `hasher`
- **Description**: "Hasher CLI: A command-line tool for hashing files and passwords."
- **Global Option**:
  - `--version` / `-v` (`bool`): Displays the application version, sourced from the assembly version.

### Subcommand: `hash-file`
- **Description**: "Hash one or more files using the specified algorithm."
- **Syntax**: `hasher hash-file <files...> [--algorithm <algorithm>] [--output <file>] [--hash-only]`
- **Arguments**:
  - `files` (`string[]`, required): One or more file paths to hash.
- **Options**:
  - `--algorithm` / `-a` (`HashingAlgorithm`, default: `SHA256`): The hashing algorithm to use (e.g., `MD5`, `SHA1`, `SHA256`, `SHA512`, `Argon2`).
  - `--output` / `-o` (`string`, optional): The file path to save the hashes. If omitted, hashes are printed to the console.
  - `--hash-only` (`bool`, optional): Print only the hash without the file path. If omitted, the output includes both the file path and hash.
- **Behavior**:
  - Hashes each file using the specified algorithm.
  - By default, outputs in the format `<file>: <hash>` (hex string with hyphens).
  - If `--hash-only` is specified, outputs only the hash without the file path.
  - If `--output` is specified, saves the output to the file; otherwise, prints to the console.
  - Handles errors (e.g., file not found) gracefully, reporting them to `Console.Error`.

### Subcommand: `hash-password`
- **Description**: "Hash a password using the specified algorithm."
- **Syntax**: `hasher hash-password [--algorithm <algorithm>]`
- **Options**:
  - `--algorithm` / `-a` (`HashingAlgorithm`, default: `Argon2`): The hashing algorithm to use (e.g., `MD5`, `SHA1`, `SHA256`, `SHA512`, `Argon2`).
- **Behavior**:
  - Prompts the user to enter a password securely (without echoing characters).
  - Hashes the password using the specified algorithm.
  - Prints the hash as a hex string to the console.

## Implementation Details

### Secure Password Input
- Passwords are read securely using a custom `ReadPassword` method that masks input with asterisks (`*`) and reads characters until Enter is pressed.

### Output Formatting
- Hashes are converted from byte arrays to hexadecimal strings using `BitConverter.ToString()`.
- For `hash-file`, the output includes the file name by default for clarity when handling multiple files, but can be set to print only the hash with the `--hash-only` option.

### Error Handling
- For `hash-file`, exceptions (e.g., `FileNotFoundException`) are caught per file, allowing the command to continue processing remaining files while reporting errors.
- For `hash-password`, any hashing errors are reported directly.

### Middleware
- The `--version` option is handled via middleware, using the assembly version for accuracy.

## Code Implementation

The following C# code implements the CLI design, including the `--hash-only` option:

```csharp
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

			// Global --version option with a clearer description
			var versionOption = new Option<bool>(
				new[] { "--version", "-v" },
				"Display the version of the application"
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
			// New --hash-only option
			var hashOnlyOption = new Option<bool>(
				new[] { "--hash-only" },
				"Print only the hash without the file path"
			);
			hashFileCommand.AddOption(hashOnlyOption);
			// Update the handler to include the new option
			hashFileCommand.SetHandler(
				(files, algorithm, output, hashOnly) => HandleHashFile(files, algorithm, output, hashOnly),
				filePathsArgument, fileAlgorithmOption, outputOption, hashOnlyOption
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

		// Handler for hash-file, updated to handle the --hash-only option
		private static void HandleHashFile(string[] files, HashingAlgorithm algorithm, string output, bool hashOnly)
		{
			var hasher = new FileHasher(algorithm);
			var results = new List<(string file, string hash)>();
			var errors = new List<(string file, string error)>();

			foreach (var file in files)
			{
				try
				{
					var hashResult = hasher.Hash(file);
					// Remove hyphens from the hash for consistency
					string hashHex = BitConverter.ToString(hashResult.Hash);
					results.Add((file, hashHex));
				}
				catch (Exception ex)
				{
					errors.Add((file, ex.Message));
				}
			}

			// Output results based on the --hash-only flag
			if (output != null)
			{
				using (var writer = new StreamWriter(output))
				{
					foreach (var (file, hash) in results)
					{
						if (hashOnly)
						{
							writer.WriteLine(hash);
						}
						else
						{
							writer.WriteLine($"{file}: {hash}");
						}
					}
				}
			}
			else
			{
				foreach (var (file, hash) in results)
				{
					if (hashOnly)
					{
						Console.WriteLine(hash);
					}
					else
					{
						Console.WriteLine($"{file}: {hash}");
					}
				}
			}

			// Report errors
			foreach (var (file, error) in errors)
			{
				Console.Error.WriteLine($"Error hashing {file}: {error}");
			}
		}

		// Handler for hash-password (unchanged)
		private static void HandleHashPassword(HashingAlgorithm algorithm)
		{
			Console.Write("Enter password: ");
			string password = ReadPassword();
			var hasher = new PasswordHasher(algorithm);
			string hash = hasher.Hash(password);
			Console.WriteLine(hash);
		}

		// Securely read password without echoing (unchanged)
		private static string ReadPassword()
		{
			string password = "";
			ConsoleKeyInfo key;
			do
			{
				key = Console.ReadKey(intercept: true);

				if (key.Key == ConsoleKey.Backspace)
				{
					if (password.Length > 0)
					{
						password = password.Remove(password.Length - 1);
						Console.Write("\b \b");
					}
				}
				else if (key.Key != ConsoleKey.Enter)
				{
					password += key.KeyChar;
					Console.Write("*");
				}
			} while (key.Key != ConsoleKey.Enter);

			Console.WriteLine();
			return password;
		}
	}
}
```

## Usage Examples

1. **Hash a Single File (Default Output)**:
   ```
   hasher hash-file document.txt
   ```
   Output: `document.txt: <SHA256_hash>`

2. **Hash a Single File with `--hash-only`**:
   ```
   hasher hash-file --hash-only document.txt
   ```
   Output: `<SHA256_hash>`

3. **Hash Multiple Files with Output File**:
   ```
   hasher hash-file file1.txt file2.txt --algorithm SHA512 --output hashes.txt
   ```
   Creates `hashes.txt` with:
   ```
   file1.txt: <SHA512_hash>
   file2.txt: <SHA512_hash>
   ```

4. **Hash Multiple Files with `--hash-only` and Output File**:
   ```
   hasher hash-file --hash-only file1.txt file2.txt --output hashes.txt
   ```
   Creates `hashes.txt` with:
   ```
   <hash1>
   <hash2>
   ```

5. **Hash a Password**:
   ```
   hasher hash-password
   ```
   Prompts: `Enter password: ****` (user types "mypassword")
   Output: `<Argon2_hash>`

6. **Check Version**:
   ```
   hasher --version
   ```
   Output: e.g., `1.0.0.0` (from assembly version)

---

This markdown file provides a comprehensive guide to the Hasher CLI, including its design, implementation, and usage examples with the `--hash-only` option.