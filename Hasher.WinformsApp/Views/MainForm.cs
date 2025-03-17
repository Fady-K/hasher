using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hasher.Core.HashingService;
using Hasher.WinformsApp.Properties;
using Hasher.WinformsApp.CustomControls;
using Hasher.Core.HashingService.Hashers;

namespace Hasher.WinformsApp.Views
{
	public partial class MainForm: Form
	{
		////////////////////////////////////////////// Fields //////////////////////////////////////////////////////////////
		private FileHasher _fileHasher;
		private Configurations _configurations;


		////////////////////////////////////////////////////////// Constructors //////////////////////////////////////////////////////////////
		public MainForm()
		{
			// Init config file path.
			InitializeComponent();

			// Add to shown event.
			this.Shown += MainForm_Shown;

			// Init local fields.
			Init();
		}

		////////////////////////////////////////////////////////// Instance Methods //////////////////////////////////////////////////////////
		// Form related events
		private void MainForm_Shown(object sender, EventArgs e)
		{
			// If first time display welcoming message and purpose of this product.
			DisplayFirstTimeMessage(_configurations.IsFirstTime);
		}

		// Btn related method.
		private void btnGenerateHash_Click(object sender, EventArgs e)
		{
			try
			{
				// Check if file path is empty or not
				if (string.IsNullOrEmpty(txtBoxFilePath.Text))
				{
					throw new HashingServiceException("File path is empty. Please enter the file path to proceed.");
				}

				// Display simulation text in the log area
				ShowSimulationMessage($"Hashing using algorithm: {cmbbxHashingAlgorithm.SelectedItem} and file: {txtBoxFilePath.Text}");

				// Simulate some processing delay (optional, to mimic a real scenario)
				Task.Delay(500).Wait();

				// Generate the hash
				string hashOutput = _fileHasher.Hash(txtBoxFilePath.Text).ToString();

				// Display the result
				CustomMessageBox.Show(hashOutput, "Hash Result");

				// Display success message
				ShowSimulationMessage("Hash generation completed successfully.");
			}
			catch (Exception ex)
			{
				// Display error message
				ShowSimulationMessage($"Error: {ex.Message}");
				MessageBox.Show(ex.Message, "Hasher Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void btnFilePath_Click(object sender, EventArgs e)
		{
			// PathSelection logic
			OpenFileDialog fileBrowserDialog = new OpenFileDialog();

			try
			{
				// Select the path using Folder browser dialogue
				if (fileBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					// Get selected path from folder browser dialog
					txtBoxFilePath.Text = fileBrowserDialog.FileName;
				}
			}
			catch (Exception ex)
			{
				// Display error message in simulation message box.
				ShowSimulationMessage($"Error: {ex.Message}");

				// Display the error message
				MessageBox.Show(ex.GetType().ToString(), ex.Message);
			}
		}

		// Cmb related methods.
		private void cmbbxHashingAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				// Get the selected hashing Algorithm
				HashingAlgorithm selectedHashingAlgorithm = (HashingAlgorithm)cmbbxHashingAlgorithm.SelectedItem;

				// Update the hashing Algoritm based on the selected algoritm
				_fileHasher.HashingStrategy = HashingStrategyFactory.CreateHashingStrategy(selectedHashingAlgorithm);
			}
			catch(Exception ex)
			{
				// Display error message
				ShowSimulationMessage($"Error: {ex.Message}");

				// Display error message
				MessageBox.Show(ex.Message, "Hasher Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		////////////////////////////////////////////////////////// Helper Methdos //////////////////////////////////////////////////////////
		private void Init()
		{
			// Init file Hasher
			_fileHasher = new FileHasher();

			// Pass ShowSimulationMessage as the delegate
			_configurations = Configurations.GetInstance(ShowSimulationMessage);

			// Populate combobox.
			PopulateHashingAlgorithmsComboBox();

			// Populate dependencies.
			PopulateDependencies();
		}
		private void PopulateDependencies()
		{
			try
			{
				// Update the file path and startegies from app settigns (history)
				txtBoxFilePath.Text = _configurations.LastSelectedFile;
				cmbbxHashingAlgorithm.SelectedIndex = Enum.TryParse<HashingAlgorithm>(_configurations.LastUsedHashingAlgorithm, out var parsedAlgorithm)
					&& cmbbxHashingAlgorithm.Items.Contains(parsedAlgorithm)
					? cmbbxHashingAlgorithm.Items.IndexOf(parsedAlgorithm)
					: 0;
			}
			catch (Exception ex)
			{
				// Display error message in simulation message box.
				ShowSimulationMessage($"Error: {ex.Message}");

				// Display error message using message box.
				MessageBox.Show(ex.Message, "Hasher Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void PopulateHashingAlgorithmsComboBox()
		{
			try
			{
				// Append them in the combobox
				cmbbxHashingAlgorithm.Items.AddRange(GetAllAvailableHashingAlgorithms()
							   .Select(hashingAlgorithm => (object)hashingAlgorithm)
							   .ToArray());
			}
			catch(Exception ex)
			{
				// Display error message
				ShowSimulationMessage($"Error: {ex.Message}");

				// Display error messsage 
				MessageBox.Show(ex.Message, "Hasher Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private HashingAlgorithm[] GetAllAvailableHashingAlgorithms()
		{
			HashingAlgorithm[] availableCiphers = Enum.GetValues(typeof(HashingAlgorithm))
											   .Cast<HashingAlgorithm>()
											   .ToArray();

			return availableCiphers;
		}
		public void DisplayFirstTimeMessage(bool isFirstTime)
		{
			if (isFirstTime)
			{
				// Ranking of supported algorithms
				string mostSecure = "Argon2";   // Strongest algorithm for cryptographic security
				string mostEfficient = "MD5";  // Fastest algorithm (not secure but efficient)
				string recommended = "SHA256"; // A balanced recommendation for security and efficiency

				string availableAlgorithms = string.Join(Environment.NewLine, GetAllAvailableHashingAlgorithms()
					.Select(algo => $"- {algo}"));

				MessageBox.Show(
					$"Welcome to Hasher! This tool is designed to help you securely generate hashes for your files using various hashing algorithms. It's user-friendly and ensures data integrity.\n\n" +
					$"Available Hashing Algorithms:\n{availableAlgorithms}\n\n" +
					$"The most secure algorithm: {mostSecure}\n" +
					$"The most efficient algorithm: {mostEfficient}\n" +
					$"The recommended algorithm: {recommended}\n\n" +
					$"We recommend using {recommended} for its excellent balance of speed and security.",
					"Welcome to Hasher!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				// Set the value = false.
				_configurations.IsFirstTime = false;
			}
		}
		private void ShowSimulationMessage(string message)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<string>(ShowSimulationMessage), message);
			}
			else
			{
				// Append the message to the log area or display in a label
				richTextBoxLog.Text = $"{DateTime.Now:HH:mm:ss} - {message}";
			}
		}
	}
}
