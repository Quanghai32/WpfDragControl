using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfDragControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        #region Controls 
        //----------------------------< Controls >---------------------------- 

        private void MainGrid_MouseMove(object sender, MouseEventArgs e)
        {
            //----------------< MainGrid_MouseMove() >---------------- 
            //*Mausbewegung im Grid 
            fp_Move_Control(sender, e);
            //----------------</ MainGrid_MouseMove() >---------------- 
        }

        private void ctlTextbox_MouseMove(object sender, MouseEventArgs e)
        {
            //----------------< ctlTextbox_MouseMove() >---------------- 
            //*Mausbewegung im Start-Control, hier eine Textbox 
            //sber nur wenn der Cursor hier ist 

            //< Cursor anpassen > 
            Mouse.OverrideCursor = Cursors.Hand;
            //</ Cursor anpassen > 

            fp_Move_Control(sender, e);

            //----------------</ ctlTextbox_MouseMove() >---------------- 
        }
        //----------------------------</ Controls >---------------------------- 
        #endregion


        #region Functions 
        //----------------------------< Functions >---------------------------- 

        private void fp_Move_Control(object sender, MouseEventArgs e)
        {
            //----------------< fp_Move_Control() >---------------- 
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (Mouse.OverrideCursor == Cursors.Hand) //nur bewegen, wenn Cursor auf Bewegung steht 
                {
                    TextBox objTextbox = ctlTextbox;
                    if (objTextbox != null)
                    {
                        //----< Move Control >---- 
                        Point mousePoint = e.GetPosition(this);

                        //< Vertical > 
                        int posY = (int)mousePoint.Y;
                        int actHeight = (int)Application.Current.MainWindow.Height;
                        int margin_Bottom = actHeight - (posY + (int)objTextbox.Height + (int)SystemParameters.CaptionHeight + (int)SystemParameters.BorderWidth + 4);
                        //</ Vertical > 

                        //< Horizontal > 
                        int posX = (int)mousePoint.X;
                        int actWidth = (int)Application.Current.MainWindow.Width;
                        int margin_Right = actWidth - (posX + (int)objTextbox.Width + (int)SystemParameters.BorderWidth);
                        //</ Horizontal > 

                        //< Objekt bewegen > 
                        objTextbox.Margin = new Thickness(posX, posY, margin_Right, margin_Bottom);
                        //</ Objekt bewegen > 

                        ctlStatus.Text = "Top=" + posY + " margin_bottom=" + margin_Bottom + " WinHeigth=" + actHeight + Environment.NewLine + " Left=" + posX + " margin_Right=" + margin_Right + "WinWidth=" + actWidth;

                        //< Cursor anpassen > 
                        Mouse.OverrideCursor = Cursors.Hand;
                        //</ Cursor anpassen > 
                        //----</ Move Control >---- 
                    }
                }
            }
            else
            {
                //< Cursor reset > 
                Mouse.OverrideCursor = Cursors.Arrow;
                //</ Cursor reset > 
            }
            //----------------< fp_Move_Control() >---------------- 

        }


        //----------------------------</ Functions >---------------------------- 

        #endregion
    }
}
