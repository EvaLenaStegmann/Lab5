using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5App
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        
        private void buttonExtract_Click(object sender, EventArgs e)
        {
            labelNoOfImages.Text = "0";
            progressBar.Value = 0;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = FormatURL(textBoxURL.Text);
                    Task<string> download = client.GetStringAsync(url);
                    listBoxImages.Items.Clear();
                    string regEx = "(?<=<img[^>]*src=\")([^\">]+)(?=\")";

                    download.Wait();

                    MatchCollection matches = Regex.Matches(download.Result, regEx, RegexOptions.IgnoreCase);
                    foreach (var match in matches)
                    {
                        if (match.ToString().Contains(".bmp") || match.ToString().Contains(".png") || match.ToString().Contains(".gif") ||
                            match.ToString().Contains(".jpg") || match.ToString().Contains(".jpeg"))
                        {
                            string imageURL = "";
                            if (Uri.IsWellFormedUriString(match.ToString(), UriKind.Relative))
                            {
                                imageURL = url + match.ToString();
                            }
                            else if (Uri.IsWellFormedUriString(match.ToString(), UriKind.Absolute))
                            {
                                imageURL = match.ToString();
                            }
                            if (imageURL != "" && !listBoxImages.Items.Contains(imageURL))
                            {
                                listBoxImages.Items.Add(imageURL);
                            }
                        }
                    }
                    labelNoOfImages.Text = listBoxImages.Items.Count.ToString();
                    progressBar.Maximum = listBoxImages.Items.Count;
                }
            }
            catch
            {
                MessageBox.Show($"Could not extract the images from {textBoxURL.Text}.");
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    progressBar.Value = 0;
                    await DownloadImagesAsync(folderBrowserDialog.SelectedPath);
                    MessageBox.Show("Download completed.");
                }
            }
        }

        private string FormatURL(string inputURL)
        {
            int length = inputURL.Length;
            if (inputURL.Substring(length - 1, 1) == "/")
            {
                inputURL = inputURL.Substring(0, length - 1);
            }

            if (inputURL.StartsWith("http://www.") || inputURL.StartsWith("https://www."))
            {
                return inputURL;
            }

            if (inputURL.StartsWith("http://") || inputURL.StartsWith("https://"))
            {
                int pos = 7;
                if (inputURL.StartsWith("https://"))
                {
                    pos++;
                }
                return inputURL.Substring(0, pos) + "www." + inputURL.Substring(pos);
            }
            else
            {
                if (inputURL.StartsWith("www."))
                {
                    return "http://" + inputURL;
                }
                else
                {
                    return "http://www." + inputURL;
                }
            }
        }

        private async Task DownloadImagesAsync(string selectedPath)
        {
            Dictionary<Task<byte[]>, string> imageDownloadTasks = new Dictionary<Task<byte[]>, string>();

            for (int i = 0; i < listBoxImages.Items.Count; i++)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    imageDownloadTasks.Add(httpClient.GetByteArrayAsync(listBoxImages.Items[i].ToString()), listBoxImages.Items[i].ToString());
                }
                catch
                {
                }
            }

            int j = 0;
            while (imageDownloadTasks.Count > 0) 
            {
                Task<byte[]> task = null;
                try
                {
                    task = await Task.WhenAny(imageDownloadTasks.Keys);
                    if (task.IsCompleted)
                    {
                        _ =  SaveImageToDiscAsync(task, Path.Combine(selectedPath, $"{GetFileNameFromURL(imageDownloadTasks[task])}" +
                                                                                   $"--{j}" +
                                                                                   $"{GetFileExtensionFromURL(imageDownloadTasks[task])}"));
                    }

                    imageDownloadTasks.Remove(task);
                }
                catch
                {
                    imageDownloadTasks.Remove(task);
                }
                j++;
                progressBar.PerformStep();
            }
        }

        private string GetFileNameFromURL(string url)
        {
            url = url.Split('?')[0];
            url = url.Split('/').Last();
            return url.Contains('.') ? url.Substring(0,url.LastIndexOf('.')) : "";
        }

        private string GetFileExtensionFromURL(string url)
        {
            url = url.Split('?')[0];
            url = url.Split('/').Last();
            return url.Contains('.') ? url.Substring(url.LastIndexOf('.')) : "";
        }

        private async Task SaveImageToDiscAsync(Task<byte[]> image, string filename)
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    await fs.WriteAsync(image.Result, 0, image.Result.Length);
                }
            }
            catch
            {
            }
        }
    }
}
