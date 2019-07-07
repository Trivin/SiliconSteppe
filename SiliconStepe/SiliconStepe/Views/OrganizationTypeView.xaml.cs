using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiliconStepe.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrganizationTypeView : ContentPage
	{
        ObservableCollection<string> Types = new ObservableCollection<string>()
        {
            "Пожарная проверка","Роспотребнадзор", "Ростехнадзор"
        };
		public OrganizationTypeView ()
		{
			InitializeComponent();
            MainListView.ItemsSource = Types;
		}
        

        private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ObservableCollection<Doc> documents = new ObservableCollection<Doc>();
            switch(MainListView.SelectedItem.ToString())
            {
                case "Пожарная проверка":
                    documents.Add(new Doc() { Name = "Акт обследования ограждения", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Акт опробования АПС(1})", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Акт перекатки пожарных рукавов(1})", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Акт по воздуховодам", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Акт по п-п дверям", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Приказ уборка отходов", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Протокол по лестнице маршевой", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Журнал инструктажей", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Протокол испытаний ПГ", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Журнал учета огнетушителей", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    break;
                case "Роспотребнадзор":
                    documents.Add(new Doc(){ Name = "Договор аренды или свидетельство о праве собственности либо иной документ, подтверждающий право пользования помещением, в котором обслуживается население.", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc(){ Name = "Договоры с предприятиями, осуществляющими дезинфекцию, дератизацию, дезинсекцию, а также вывоз отходов и мусора.", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc(){ Name = "Журнал учета санитарных проверок.", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc(){ Name = "Медицинские книжки работников с отметками о прохождении медицинского осмотра.", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc(){ Name = "Экспертные заключения на товары, сертификаты или заключения об их качестве.", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc(){ Name = "При необходимости — лицензия или свидетельство об аккредитации, полученные для осуществления особых видов деятельности.", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc(){ Name = "Учредительные документы предприятия со всеми последними изменениями.", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc(){ Name = "Программа контроля на производстве, оформленная должным образом.", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    break;
                case "Ростехнадзор":
                    documents.Add(new Doc() { Name = "Карточка организации, где указаны ее наименование, юридический и почтовый адреса, организационно- правовая форма, ФИО руководителя и гл. бухгалтера, ОГРН, ИНН/КПП, коды статистики, банковские реквизиты, контактные данные.", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Документ, подтверждающий право собственности/владения ОПО", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Предписания, ранее полученные от Ростехнадзора (при наличии таковых}).", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Свидетельство о государственной регистрации юридического лица (ИП})", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Свидетельство о постановке на учет в налоговом органе (ИНН/КПП})", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Устав организации", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "штатное расписание, включая приказ руководителя об утверждении штатного расписания", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "квалификация работников, включая проверку отсутствия медицинских противопоказаний", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Разрешение (акт) на ввод в эксплуатацию оборудования, которое используется на ОПО", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Сведения (отчет) об организации производственного контроля за соблюдением требований промышленной безопасности на ОПО за прошедший год.", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    documents.Add(new Doc() { Name = "Декларация промышленной безопасности (если объект декларируемый}).", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga")});
                    break;
            }
            MainListView.SelectedItem = null;
            Navigation.PushAsync(new DocumentationView(documents));
        }
    }

    public class Doc
    {
        public string Name { get; set; }
        public Uri Uri { get; set; }
    }
}