using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoProtecto {
    class Cajita : Panel{
        double ancho;
        double alto;
        double x;

        public void RecargarCajita(double ancho, double alto, double x) {
            this.ancho = ancho;
            this.alto = alto;
            this.x = x;
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            Pen p = new Pen(Color.Black); 
            Pen p2 = new Pen(Color.FromArgb(25,0,0,0));
            Pen p3 = new Pen(Color.FromArgb(190,0,0,0));
            Graphics g = e.Graphics;
            
            double aspectRatio = ancho / alto;
            double anchoReal = (aspectRatio >= 1 ? (Width-1) : Width * aspectRatio);
            double altoReal = (aspectRatio >= 1 ? (Height-1) / aspectRatio : (Height-1));
            double escala = anchoReal / ancho;
            double xReal = x * escala;
            Rectangle cajaCompleta = new Rectangle(new Point((Width-(int)anchoReal)/2, (Height - (int)altoReal) / 2), new Size((int)anchoReal, (int)altoReal));
            g.DrawRectangle(p, cajaCompleta);
            Rectangle cajaCentro = new Rectangle(new Point((Width - (int)(anchoReal - 2 * xReal)) / 2, (Height - (int)(altoReal - 2 * xReal)) / 2), new Size((int)(anchoReal - 2 * xReal), (int)(altoReal - 2 * xReal)));
            g.DrawRectangle(p3, cajaCentro);
            Rectangle CuadritoACortar = new Rectangle(new Point((Width - (int)anchoReal - 2) / 2, (Height - (int)(altoReal - 2 * xReal)) / 2), new Size((int)(anchoReal), (int)(altoReal - 2 * xReal)));
            g.DrawRectangle(p2, CuadritoACortar);
            CuadritoACortar = new Rectangle(new Point((Width - (int)(anchoReal - 2 * xReal)) / 2, (Height - (int)altoReal) / 2), new Size((int)(anchoReal - 2 * xReal), (int)altoReal));
            g.DrawRectangle(p2, CuadritoACortar);
            g.DrawString(x.ToString(), new Font("sans-serif", 10), p3.Brush, new Point((Width - (int)(anchoReal - 2 * xReal)) / 2, (int)((Height - (int)(altoReal - 2 * xReal)) / 2 + (int)(altoReal - 1.75 * xReal))));
            g.DrawString((ancho-2*x).ToString(), new Font("sans-serif", 10), p3.Brush, new Point((Width - (int)(anchoReal - 2 * xReal)) / 2, (int)((Height - (int)(altoReal - 2 * xReal)) / 2) + (int)(altoReal * .333)));
            g.DrawString((alto - 2 * x).ToString(), new Font("sans-serif", 10), p3.Brush, new Point((Width - (int)(anchoReal - 2 * xReal)) / 2 + (int)(anchoReal * .2), (int)((Height - (int)(altoReal - 2 * xReal)) / 2)));

        }
    }
}
