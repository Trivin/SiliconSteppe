﻿using SiliconStepe.API;
using SiliconStepe.Classes;
using SiliconStepe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static SiliconStepe.App;

namespace SiliconStepe.ViewModels
{
    public class ArchiveInvitesPageViewModel
    {
        private List<Invite> _Invites = new List<Invite>();
        public List<Invite> Invites
        {
            get => _Invites;
            set
            {
                if (value != _Invites)
                {
                    _Invites = value;
                    OnPropertyChanged("Invites");
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
                    await GetInvites();
                    IsRefreshing = false;
                });
            }
        }

        public async Task GetInvites()
        {
            try
            {
                Invites = (await InvitesApi.GetActiveInvites(CurrentProperties.CurrentUser.Token));
            }
            catch (CustomException exc)
            {
                DependencyService.Get<IMessage>().ShortAlert(exc.Message);
                OnLoaded(this);
                return;
            }
            catch
            {
                Invites = new List<Invite>()
                {
                    new Invite()
                    {
                        Worker = new User()
                        {
                            SecondName = "Попов",
                            FirstName = "Петр",
                            MiddleName = "Александрович",
                        },
                        Employee = new User()
                        {
                            SecondName = "Иванов",
                            FirstName = "Иван",
                            MiddleName = "Иванович",
                            Organization = new Organization()
                            {
                                Name = "Магазин №2",
                                OrganizationType = new OrganizationType()
                                {
                                    Name = "Магазин",
                                }
                            },
                        },
                        DateTime = DateTime.Now.AddDays(1),
                        Status = true,
                        Description = "Описание чего-то большого интересноого фкусного крутого простого и необычного",
                    },

                    new Invite()
                    {
                        Worker = new User()
                        {
                            SecondName = "Попов1",
                            FirstName = "Петр1",
                            MiddleName = "Александрович1",
                        },
                        Employee = new User()
                        {
                            SecondName = "Иванов1",
                            FirstName = "Иван1",
                            MiddleName = "Иванович1",
                            Organization = new Organization()
                            {
                                Name = "Магазин №2",
                                OrganizationType = new OrganizationType()
                                {
                                    Name = "Магазин",
                                }
                            },
                        },
                        DateTime = DateTime.Now.AddDays(1),
                        Status = true,
                        Description = "Короткое описание",
                    },
                };
                //Payments = null;
            }
            if (Invites == null)
            {
                DependencyService.Get<IMessage>().LongAlert("Произошла ошибка получения списка обращений!");
            }
            OnLoaded(this);
            return;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
