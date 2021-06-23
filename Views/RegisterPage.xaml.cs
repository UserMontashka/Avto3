using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Avto.Models;
using Avto.Controllers;

namespace Avto.Views
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        Core db ;
        public Users usersobj;
        UserController obj = new UserController();
        public RegisterPage()
        {
            InitializeComponent();
            db = new Core();
            RolesComboBox.ItemsSource = db.context.roles.ToList();
            RolesComboBox.DisplayMemberPath = "name_roles";
            RolesComboBox.SelectedValuePath = "id_roles";
            PasportTextBox.MaxLength = 10;
            DriverLicenceTextBox.MaxLength =9;

    }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            bool udost = obj.TextUdostoverenie(DriverLicenceTextBox.Text);
            bool pasport = obj.TextPaspportNumber(PasportTextBox.Text);
            if (NameTextBox.Text == "" || SurnameTextBox.Text == "" || PatronymicTextBox.Text == "" || EmailTextBox.Text == "" || PassTextBox.Text == "" || PasportTextBox.Text == "" || AdressTextBox.Text == "" || DriverLicenceTextBox.Text == "" || RolesComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                string login = EmailTextBox.Text;
                bool kak = true;
                usersobj = db.context.Users.Where(x => x.login == login).FirstOrDefault();
                if (usersobj == null)
                {
                    if(udost&& pasport)
                    kak = false;
                    if (!pasport || !udost)
                    kak = true;
                    MessageBox.Show("Неверный формат паспорта или удостовирения");
                }
                else
                {
                    kak = true;
                }
                if (kak == false)
                {
                    MessageBox.Show("ОК");
                    Client objectClient = new Client()
                    {
                        name = NameTextBox.Text,
                        sname = SurnameTextBox.Text,
                        patronymic = PatronymicTextBox.Text,
                        email = EmailTextBox.Text,
                        drivers_licensed = DriverLicenceTextBox.Text,
                        seria_passport = PasportTextBox.Text,
                        address = AdressTextBox.Text,
                    };
                    db.context.Client.Add(objectClient);
                    db.context.SaveChanges();

                    var resul = db.context.Client.Where(x => x.name == NameTextBox.Text).First();
                    int id = resul.id_client;
                    Users addlog = new Users()
                    {
                        login = EmailTextBox.Text,
                        password = PassTextBox.Text,
                        id_roles = Convert.ToInt32(RolesComboBox.SelectedValue),
                        id_client = id
                    };
                    db.context.Users.Add(addlog);
                    db.context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Такая почта уже используется");
                    return;
                }


                MessageBox.Show("Пользователь добавлен");

                string email = EmailTextBox.Text.Trim();
                string password = PassTextBox.Text.Trim();
                if ((email.Contains("@") && email.Contains(".")))
                {


                    // отправитель - устанавливаем адрес и отображаемое в письме имя
                    MailAddress from = new MailAddress("prokatavto84@gmail.com", "ProkatAvto");
                    // кому отправляем
                    MailAddress to = new MailAddress(email);
                    // создаем объект сообщения
                    MailMessage m = new MailMessage(from, to);
                    // тема письма
                    m.Subject = "Пароль и логин для входа в аккаунт ProkatAvto";
                    // текст письма
                    //TODO написать норм разметку для письма
                    m.Body = "<h4>Здравствуйте, " + email + "</h4>"
                                + "<p><font-size: 18px>Логин: " + email + "</p>" + "<p><font-size = 18>Пароль: " + password + "</p>"
                                + "<p><font-size: 18px>Если вы не делали запрос на отправку данных, ответье на это письмо: " + "<span><font-size:22px; color: red>";
                    // письмо представляет код html
                    m.IsBodyHtml = true;
                    // адрес smtp-сервера и порт, с которого будем отправлять письмо
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    // логин и пароль
                    smtp.Credentials = new NetworkCredential("prokatavto84@gmail.com", "Go_Hyd_Ra4343");
                    smtp.EnableSsl = true;
                    try
                    {
                        smtp.Send(m);
                    }
                    catch
                    {

                    }
                }
            }

        }
       
    }
}
