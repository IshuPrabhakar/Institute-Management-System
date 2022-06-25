using IMS.Commands;
using IMS.Helpers;
using IMS.Model;
using IMS.Model.HelperModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IMS.ViewModel
{
    public class InstituteViewModel : INotifyPropertyChanged
    {
        public InstituteConfigModel Config { get; set; }
        public ObservableCollection<EductionalDetails> EductionalDetailsList { get; set; }
        public ObservableCollection<RequiredDocs> RequiredDocuments { get; set; }
        public ObservableCollection<StudentSession> Sessions { get; set; }

        /// <summary>
        /// Local Variable for databinding
        /// </summary>
        private string sessionTextBox;
        private string appliedToTextBox;
        private string edTitle;
        private bool isRequired;
        private string docTitle;

        public string SessionTextBox { get => sessionTextBox; set { sessionTextBox = value; OnPropertyChanged("sessionTextBox"); } }
        public string AppliedToTextBox { get => appliedToTextBox; set { appliedToTextBox = value; OnPropertyChanged("appliedToTextBox"); } }
        public string EdTitle { get => edTitle; set { edTitle = value; OnPropertyChanged("edTitle"); } }
        public bool IsRequired { get => isRequired; set { isRequired = value; OnPropertyChanged("isRequired"); } }
        public string DocTitle { get => docTitle; set { docTitle = value; OnPropertyChanged("docTitle"); } }
        /// <summary>
        /// End
        /// </summary>

        public InstituteViewModel()
        {
            Config = new InstituteConfigModel();
            EductionalDetailsList = new ObservableCollection<EductionalDetails>();
            Sessions = new ObservableCollection<StudentSession>();
            RequiredDocuments = new ObservableCollection<RequiredDocs>();
            //EductionalDetailsList = null;

            // CAMMAND INVOKATION   
            AddNewSession = new CommandBase(AddSession);
            SaveConfiguration = new CommandBase(SaveConfig);
            EditItem = new CommandBase(EditListItem);
            RemoveItem = new CommandBase(RemoveListItem);
            // CAMMAND INVOKATION END

            RetriveConfig();

        }

        /// <summary>
        /// INOTIFY CHANGED INTERFACE
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        /// <summary>
        /// END
        /// </summary>

        public void RetriveConfig()
        {
            // "iConfig.secure" = filename
            // type Should be type of DataModel Which has to retrived
            try
            {
                SettingHelper helper = new SettingHelper();
                Config = helper.Retrive("iConfig.json", typeof(InstituteConfigModel)) as InstituteConfigModel;
                if (Config == null)
                {
                    return;
                }
                Sessions = Config.Sessions;
                EductionalDetailsList = Config.EducationalDetailsList;
                RequiredDocuments = Config.RequiredDocumentsList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Commands
        /// </summary>
        public CommandBase AddNewSession { get; set; }
        public CommandBase RemoveItem { get; set; }
        public CommandBase SaveConfiguration { get; set; }
        public CommandBase EditItem { get; set; }
        /// <summary>
        /// Commands
        /// End 
        /// </summary>

        /// COMMANDS IMPLIMENTATION
        private void AddSession(object parameter)
        {
            object DataContext = parameter;
            //System.Diagnostics.Debug.WriteLine(DataContext.ToString());
            try
            {
                if (DataContext.ToString() == "SessionTextBox")
                {
                    StudentSession temp = new StudentSession
                    {
                        No = Sessions == null ? 1 : Sessions.Count() + 1,
                        Date = DateTime.Now.ToString(),
                        AddedBy = "Admin",
                        AppliedTo = AppliedToTextBox,
                        Session = SessionTextBox
                    };
                    Sessions.Add(temp);
                    _ = temp;
                }
                else if (DataContext.ToString() == "DocumentTitle")
                {
                    EductionalDetails temp = new EductionalDetails
                    {
                        No = EductionalDetailsList == null ? 1 : EductionalDetailsList.Count() + 1,
                        Title = EdTitle,
                        AddedBy = "Admin",
                        Date = DateTime.Now.ToString()
                    };
                    EductionalDetailsList.Add(temp);
                    _ = temp;
                }
                else
                {
                    //System.Diagnostics.Debug.WriteLine(DocTitle);
                    RequiredDocs temp = new RequiredDocs
                    {
                        No = RequiredDocuments == null ? 1 : RequiredDocuments.Count() + 1,
                        Title = DocTitle,
                        IsRequired = IsRequired,
                        Date = DateTime.Now.ToString(),
                        AddedBy = "Admin"
                    };
                    RequiredDocuments.Add(temp);
                    _ = temp;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            //System.Diagnostics.Debug.WriteLine("HELLO.......... " + count);
        }

        private void RemoveListItem(object obj)
        {
            object DataContext = obj;
            if (DataContext.ToString() == "IMS.Model.StudentSession")
            {
                StudentSession item = DataContext as StudentSession;
                Config.Sessions.RemoveAt(Config.Sessions.IndexOf(item));
            }
            else if (DataContext.ToString() == "IMS.Model.EductionalDetails")
            {
                EductionalDetails Eitem = DataContext as EductionalDetails;
                Config.EducationalDetailsList.RemoveAt(Config.EducationalDetailsList.IndexOf(Eitem));
            }
            else
            {
                RequiredDocs Ritem = DataContext as RequiredDocs;
                Config.RequiredDocumentsList.RemoveAt(Config.RequiredDocumentsList.IndexOf(Ritem));
            }
        }

        private void EditListItem(object obj)
        {
            object DataContext = obj;
            //System.Diagnostics.Debug.WriteLine(DataContext);

            try
            {
                if (DataContext.ToString() == "IMS.Model.StudentSession")
                {
                    StudentSession temp = new StudentSession();
                    StudentSession item = DataContext as StudentSession;
                    temp = Sessions[Sessions.IndexOf(item)];
                    SessionTextBox = temp.Session;
                    AppliedToTextBox = temp.AppliedTo;
                }
                else if (DataContext.ToString() == "IMS.Model.EductionalDetails")
                {
                    EductionalDetails temp = new EductionalDetails();
                    EductionalDetails item = DataContext as EductionalDetails;
                    EdTitle = Config.EducationalDetailsList[Config.EducationalDetailsList.IndexOf(item)].Title;
                }
                else
                {
                    RequiredDocs temp = new RequiredDocs();
                    RequiredDocs item = DataContext as RequiredDocs;
                    temp = RequiredDocuments[RequiredDocuments.IndexOf(item)];
                    DocTitle = temp.Title;
                    IsRequired = temp.IsRequired;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        public void SaveConfig(object parameter)
        {
            // "iConfig.secure" = filename
            // type Should be type of DataModel Which has to Save.......
            SettingHelper helper = new SettingHelper();
            Config.Sessions = Sessions;
            Config.RequiredDocumentsList = RequiredDocuments;
            Config.EducationalDetailsList = EductionalDetailsList;
            helper.Save(Config, "iConfig.json", typeof(InstituteConfigModel));
        }
    }
}
