﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace EventDetails
{
    public sealed partial class Register : Page
    {
        public string token, type, dept;

        public Register()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            token = e.Parameter.ToString();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            type = item.Content.ToString();

            if (item.Content.ToString() == "Technical")
            {
                Department.IsEnabled = true;
            }
            else
                Department.IsEnabled = false;
        }

        public int r_Count = 2;

        public void AddRound_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (r_Count > 5) throw new Exception();
                {
                    Warning2.Visibility = Visibility.Collapsed;
                    TextBox t = new TextBox();
                    t.Name = "Round" + r_Count;
                    t.PlaceholderText = "Round " + r_Count;
                    t.HorizontalAlignment = HorizontalAlignment.Stretch;
                    t.VerticalAlignment = VerticalAlignment.Stretch;
                    t.Height = 100;
                    t.TextWrapping = TextWrapping.Wrap;
                    t.Margin = new Thickness(0, 10, 0, 0);
                    t.Foreground = TextBox1.Foreground;
                    Rounds.Children.Add(t);
                    Rounds.UpdateLayout();
                    r_Count++;
                }
            }
            catch(Exception)
            {
                Warning2.Text = "Can not add more than 5 rounds";
                Warning2.Visibility = Visibility.Visible;
            }
        }

        public void RemoveRound_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (r_Count < 3) throw new Exception();
                --r_Count;
                TextBox t = (TextBox)this.Rounds.FindName("Round" + (r_Count));
                this.Rounds.Children.Remove(t);
                Rounds.UpdateLayout();
                Warning2.Visibility = Visibility.Collapsed;
            }
            catch(Exception)
            {
                Warning2.Text = "Atleast one round is required";
                Warning2.Visibility = Visibility.Visible;
            }
        }

        public int m_Count = 2;

        public void Add_Manager(object sender, RoutedEventArgs e)
        {
            try
            {
                if (m_Count > 5) throw new Exception();
                {
                    Warning1.Visibility = Visibility.Collapsed;

                    TextBlock tb = new TextBlock();
                    tb.Name = "Manager" + m_Count;
                    tb.Text = "Manager " + m_Count;
                    tb.Margin = new Thickness(0, 10, 0, 0);
                    tb.HorizontalAlignment = HorizontalAlignment.Stretch;
                    tb.VerticalAlignment = VerticalAlignment.Stretch;
                    tb.Foreground = TextBox1.Foreground;
                    Manager.Children.Add(tb);
                    Rounds.UpdateLayout();

                    TextBox t = new TextBox();
                    t.Name = "ManagerName" + m_Count;
                    t.PlaceholderText = "Name";
                    t.HorizontalAlignment = HorizontalAlignment.Stretch;
                    t.VerticalAlignment = VerticalAlignment.Stretch;
                    t.Margin = new Thickness(0, 10, 0, 0);
                    t.TextWrapping = TextWrapping.Wrap;
                    t.Foreground = TextBox1.Foreground;
                    Manager.Children.Add(t);
                    Rounds.UpdateLayout();

                    TextBox n = new TextBox();
                    n.Name = "Number" + m_Count;
                    n.PlaceholderText = "Phone Number";
                    n.Margin = new Thickness(0, 10, 0, 0);
                    n.HorizontalAlignment = HorizontalAlignment.Stretch;
                    n.VerticalAlignment = VerticalAlignment.Stretch;
                    n.Foreground = TextBox1.Foreground;
                    n.TextWrapping = TextWrapping.Wrap;
                    Manager.Children.Add(n);
                    Rounds.UpdateLayout();

                    m_Count++;
                }
            }
            catch(Exception)
            {
                Warning1.Text = "Can not add more than 5 managers";
                Warning1.Visibility = Visibility.Visible;
            }
        }

        public void Remove_Manager(object sender, RoutedEventArgs e)
        {
            try
            {
                if (m_Count < 3) throw new Exception();
                --m_Count;
                TextBlock tb = (TextBlock)this.Manager.FindName("Manager" + (m_Count));

                this.Manager.Children.Remove(tb);
                Manager.UpdateLayout();

                TextBox t = (TextBox)this.Manager.FindName("ManagerName" + (m_Count));
                this.Manager.Children.Remove(t);
                Manager.UpdateLayout();

                TextBox n = (TextBox)this.Manager.FindName("Number" + (m_Count));
                this.Manager.Children.Remove(n);
                Manager.UpdateLayout();

                Warning1.Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {
                Warning1.Text = "Atleast one manager is required";
                Warning1.Visibility = Visibility.Visible;
            }
        }

        public void Department_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            dept = item.Content.ToString();
        }

        public async void submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ring.IsActive = true;
                submit.IsEnabled = false;
                Invalid.Visibility = Visibility.Collapsed;
                Details d = new Details();
                d.eventName = TextBox1.Text.ToString();
                d.eventType = type;

                if (Department.IsEnabled == true)
                    d.department = dept;
                else
                    d.department = "";

                d.tagline = TextBox2.Text.ToString();
                d.description = TextBox3.Text.ToString();
                d.teamSize = Convert.ToInt32(TextBox4.Text);
                d.entryFee = Convert.ToInt32(TextBox5.Text);

                ArrayList prize = new ArrayList();
                prize.Add(Winner.Text.ToString());
                prize.Add(Runner_Up.Text.ToString());

                d.prizeMoney = new List<int>();
                int p_Count = 0;
                while(p_Count < prize.Count)
                {
                    d.prizeMoney.Add(Convert.ToInt32(prize[p_Count]));
                    p_Count++;
                }

                ArrayList names = new ArrayList();
                ArrayList phone = new ArrayList();
                ArrayList round = new ArrayList();

                names.Add(TextBox6.Text.ToString());
                phone.Add(TextBox7.Text.ToString());
                round.Add(TextBox8.Text.ToString());

                int counter = 2;
                while (counter < m_Count)
                {
                    TextBox n = (TextBox)this.Manager.FindName("ManagerName" + (counter));
                    TextBox p = (TextBox)this.Manager.FindName("Number" + (counter));
                    counter++;

                    names.Add(n.Text.ToString());
                    phone.Add(p.Text.ToString());
                }

                counter = 2;
                while (counter < r_Count)
                {
                    TextBox r = (TextBox)this.Rounds.FindName("Round" + (counter));
                    counter++;

                    round.Add(r.Text.ToString());                    
                }
                
                d.managers = new List<Managers>();
                int k = 0, l = 0;

                while (k < names.Count)
                {
                    Managers m1 = new Managers();
                    m1.name = names[k].ToString();
                    m1.phone = phone[k].ToString();
                    d.managers.Add(m1);
                    k++;
                }

                d.rounds = new List<string>();
                while (l < round.Count)
                {
                    d.rounds.Add(round[l].ToString());
                    l++;
                }

                string uri = "http://udaan18-events-api.herokuapp.com/events";
                ResponseObject response = await Submit.PostAsJsonAsync(uri, d, token);

                if (response.status == true)
                {
                    this.Frame.Navigate(typeof(Finish), token);
                    Ring.IsActive = false;
                }
                else
                {
                    Ring.IsActive = false;
                    Invalid.Text = "Submission unsuccessfull. (Are you missing any field..?)";
                    Invalid.Visibility = Visibility.Visible;
                    submit.IsEnabled = true;
                }
            }
            catch(Exception)
            {
                Ring.IsActive = false;
                Invalid.Text = "Each field is complusory with respective type..!";
                Invalid.Visibility = Visibility.Visible;
                submit.IsEnabled = true;
            }
        }

        public void logoutbutton_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        public void backbutton_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Choice), token);
        }
    }
}