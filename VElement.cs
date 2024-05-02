using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaBall2_0
{
    public class VElement
    {
        public List<VPoint> Points;
        public List<VPole> Poles;


        public List<Pin> Pines;

        int width;
        int height;
        public VElement(int width, int heigth)
        {
            Init(width, heigth);
        }
        public void Init(int width, int heigth)
        {
            this.width = width;
            this.height = heigth;
            Points = new List<VPoint>();
            Poles = new List<VPole>();
            Pines = new List<Pin>();


        }
        public void Clear()
        {
            //Points.Clear(); Poles.Clear(); bodies.Clear(); Cuerdas.Clear(); Pines.Clear();
        }
        public void addPoint(VPoint pointn)
        {
            Points.Add(pointn);
        }
        public void addPole(VPole pole)
        {
            Poles.Add(pole);
        }
        public void addPin(Pin pin)
        {
            Pines.Add(pin);
        }
        public void AdministratorPoints(int s, int p)
        {
            VPoint p1 = Points[s];
            VPoint p2 = Points[p];
            //if (p1.IsBubble && p2.IsEstrella) return;
            if (p1.pelotadentro == p2)
            {
                p2.pos = p1.pos;
                return;
            }

            if (p1.Id == p2.Id) // BY ID
                return;
            if (p1.IsPinned && p2.IsPinned)
                return;
            Vec2 axis = p1.pos - p2.pos; // vector de direccion
            float dis = axis.Length(); // magnitud
            if (dis < (p1.radius + p2.radius))//COLLISION DETECTED
            {
                if (p1.isTangible && p2.isTangible)
                {
                    // dividir la fuerza para repartir entre ambas colisiones
                    float dif = (dis - (p1.radius + p2.radius)) * 0.2f;
                    Vec2 normal = axis / dis; // normalizar la direccion para tener el vector unitario
                    Vec2 res = dif * normal; // vector resultante

                    if (!p1.IsPinned)
                        if (p2.IsPinned)
                            p1.pos -= res * 1.2f;
                        else
                            p1.pos -= res;
                    if (!p2.IsPinned)
                        if (p1.IsPinned)
                            p2.pos += res * 1.2f;
                        else
                            p2.pos += res;
                }
                else
                {
                    p1.isActive = false;
                    p2.isActive = false;
                    Global.puntaje += !p1.isTangible ? p1.value : p2.value;
                }

            }
        }
        public void Update()
        {
            for (int s = 0; s < Points.Count; s++)
            {
                Points[s].Update();
                //AdministratorPoles(s);
                for (int p = 0; p < Points.Count; p++)
                {
                    AdministratorPoints(s, p);
                }
            }
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i].Update();
                Points[i].Constraints();
            }



        }
        public void Render(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                if (Points[i].isPin && Points[i].IsVisible)
                {
                    Global.spritePin.UpdateSprite(Points[i].pos.X - Points[i].radius - Global.cameraMono.Position.X,
                        Points[i].pos.Y - Points[i].radius);
                    _spriteBatch.Draw(Global.spritePin.texture, Global.spritePin.rectangle, Color.White);
                }
                if (Points[i].IsCaramelo && !Global.won)
                {
                    Global.spriteCaramelo.UpdateSprite(Points[i].pos.X - Points[i].radius - Global.cameraMono.Position.X,
                        Points[i].pos.Y - Points[i].radius);
                    _spriteBatch.Draw(Global.spriteCaramelo.texture, Global.spriteCaramelo.rectangle, Color.White);
                }
            }

        }
    }
}
