using System;
using System.IO;
using System.Windows.Forms;

namespace YourApplicationNamespace
{
    public static class Program
    {
        private static string dataFilePath = "userdata.csv";
        private static Form mainForm;
        private static TextBox nameTextBox;
        private static TextBox phoneTextBox;
        private static TextBox emailTextBox;

        [STAThread]
        public static void Main()
        {
            // Створення головної форми
            mainForm = new Form();
            mainForm.Text = "Введіть дані";
            mainForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.AutoSize = true;

            // Створення полів для введення даних
            nameTextBox = new TextBox();
            nameTextBox.Location = new System.Drawing.Point(10, 10);
            nameTextBox.Width = 200;
            mainForm.Controls.Add(nameTextBox);

            phoneTextBox = new TextBox();
            phoneTextBox.Location = new System.Drawing.Point(10, 40);
            phoneTextBox.Width = 200;
            mainForm.Controls.Add(phoneTextBox);

            emailTextBox = new TextBox();
            emailTextBox.Location = new System.Drawing.Point(10, 70);
            emailTextBox.Width = 200;
            mainForm.Controls.Add(emailTextBox);

            // Створення кнопки для збереження даних
            Button saveButton = new Button();
            saveButton.Text = "Зберегти";
            saveButton.Location = new System.Drawing.Point(10, 100);
            saveButton.Click += SaveButton_Click;
            mainForm.Controls.Add(saveButton);

            // Відображення головної форми
            Application.Run(mainForm);
        }

        private static void SaveButton_Click(object sender, EventArgs e)
        {
            // Отримання введених даних
            string name = nameTextBox.Text;
            string phone = phoneTextBox.Text;
            string email = emailTextBox.Text;

            // Збереження даних
            SaveUserData(name, phone, email);

            // Виведення повідомлення
            MessageBox.Show("Дані були успішно збережені у файлі userdata.csv.");

            // Закриття головної форми
            mainForm.Close();
        }

        private static void SaveUserData(string name, string phone, string email)
        {
            using (StreamWriter writer = new StreamWriter(dataFilePath, true))
            {
                writer.WriteLine($"Ім'я: {name}");
                writer.WriteLine($"Телефон: {phone}");
                writer.WriteLine($"Електронна пошта: {email}");
                writer.WriteLine(new string('-', 20));
            }
        }
    }
}
