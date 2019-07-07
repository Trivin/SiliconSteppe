using SiliconStepe.Classes;
using SiliconStepe.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static SiliconStepe.App;

namespace SiliconStepe.ViewModels
{
    class EmployeesPageViewModel : INotRealization
    {
        List<User> employees = new List<User>();
        public List<User> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                if (value != employees)
                {
                    employees = value;
                    OnPropertyChanged("Employees");
                }
            }
        }
        public delegate void OnDataLoaded(object sender);
        public event OnDataLoaded OnLoaded;

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    await GetParticipants();
                    IsRefreshing = false;
                });
            }
        }
        public async Task GetParticipants()
        {
            try
            {
                //Employees = (await ParticipantApi.GetParticipants(CurrentProperties.CurrentUser.Token));
            }
            catch (CustomException exc)
            {
                DependencyService.Get<IMessage>().ShortAlert(exc.Message);
                OnLoaded(this);
                return;
            }
            catch
            {
                Employees = new List<User>()
                {
                    new User()
                    {
                        FirstName = "Юрий",
                        MiddleName = "Дмитриевич",
                        SecondName = "Яровой",
                        Rate = new List<Rate>()
                        {
                            new Rate()
                            {
                                Score = 5
                            },
                            new Rate()
                            {
                                Score = 4
                            },
                            new Rate()
                            {
                                Score = 2
                            },
                            new Rate()
                            {
                                Score = 1
                            },
                        },
                    },
                    new User()
                    {
                        FirstName = "Александр",
                        MiddleName = "Михайлович",
                        SecondName = "Васильев",
                        Rate = new List<Rate>()
                        {
                            new Rate()
                            {
                                Score = 5
                            },
                            new Rate()
                            {
                                Score = 5
                            },
                            new Rate()
                            {
                                Score = 2
                            },
                            new Rate()
                            {
                                Score = 5
                            },
                        },
                    },
                    new User()
                    {
                        FirstName = "Виктор",
                        MiddleName = "Вячеславович",
                        SecondName = "Петров",
                        Rate = new List<Rate>()
                        {
                            new Rate()
                            {
                                Score = 2
                            },
                            new Rate()
                            {
                                Score = 2
                            },
                            new Rate()
                            {
                                Score = 2
                            },
                            new Rate()
                            {
                                Score = 1
                            },
                        },
                    },
                    new User()
                    {
                        FirstName = "Иван",
                        MiddleName = "Иванович",
                        SecondName = "Иванов",
                        Rate = new List<Rate>()
                        {
                            new Rate()
                            {
                                Score = 1
                            },
                            new Rate()
                            {
                                Score = 1
                            },
                            new Rate()
                            {
                                Score = 2
                            },
                            new Rate()
                            {
                                Score = 3
                            },
                        },
                    },
                };
                //Participants = null;
            }
            Employees = new List<User>()
                {
                    new User()
                    {
                        FirstName = "Юрий",
                        MiddleName = "Дмитриевич",
                        SecondName = "Яровой",
                        Rate = new List<Rate>()
                        {
                            new Rate()
                            {
                                Score = 5
                            },
                            new Rate()
                            {
                                Score = 4
                            },
                            new Rate()
                            {
                                Score = 2
                            },
                            new Rate()
                            {
                                Score = 1
                            },
                        },
                    },
                    new User()
                    {
                        FirstName = "Александр",
                        MiddleName = "Михайлович",
                        SecondName = "Васильев",
                        Rate = new List<Rate>()
                        {
                            new Rate()
                            {
                                Score = 5
                            },
                            new Rate()
                            {
                                Score = 5
                            },
                            new Rate()
                            {
                                Score = 2
                            },
                            new Rate()
                            {
                                Score = 5
                            },
                        },
                    },
                    new User()
                    {
                        FirstName = "Виктор",
                        MiddleName = "Вячеславович",
                        SecondName = "Петров",
                        Rate = new List<Rate>()
                        {
                            new Rate()
                            {
                                Score = 2
                            },
                            new Rate()
                            {
                                Score = 2
                            },
                            new Rate()
                            {
                                Score = 2
                            },
                            new Rate()
                            {
                                Score = 1
                            },
                        },
                    },
                    new User()
                    {
                        FirstName = "Иван",
                        MiddleName = "Иванович",
                        SecondName = "Иванов",
                        Rate = new List<Rate>()
                        {
                            new Rate()
                            {
                                Score = 1
                            },
                            new Rate()
                            {
                                Score = 1
                            },
                            new Rate()
                            {
                                Score = 2
                            },
                            new Rate()
                            {
                                Score = 3
                            },
                        },
                    },
                };
            if (Employees == null)
            {
                DependencyService.Get<IMessage>().LongAlert("Произошла ошибка получения списка участников!");
            }
            OnLoaded(this);
            return;
        }
    }
}
