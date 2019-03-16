/*  Great Circle Calculator
 *  
 *  This program calculayes various pieces of information about the "Great Circle" based on the Latitude and Longitude
 *  provided by the user. A Great Circle is the shortest distance between two points on a sphere - the Earth in this case.
 *  Coordinates are entered in the form 'XXdYYmZZs' - XX Degrees YY Minutes ZZ Seconds - and converted into a decimal value.
 *  
 *  For these comments, the Start position will be refered to as Latitude1 or Longitude1
 *  and the Finish positiion will be Latitude2 or Longitude2.
 *  
 *  'dLong' refers to the angular distance between two points of longitude.
 *  eg. dLong between 20 Degrees 00 Minutes East, and 30 Degrees 00 Minutes East, is 10 Degrees East (Directional)
 *  
 *  Cos(Distance) = Cos(dLong) * Cos(Latitude1) * Cos(Latitude2) +/- Sin(Latitude1) * Sin(Latitude2)
 *  If the Start/End Latitudes are in the same Hemisphere, we add. If They are not, we subtract.
 *  Distance is returned in Nautical Miles.
 *  
 *  Initial Course - The angle in Degrees True, from North, in the direction of the second position.
 *  Formulae give this as a Quadrantal, expressed from either North or South, then East or West.
 *  eg North 45 East -> 045 Degrees True. South 45 Degrees East -> 180 - 45 -> 135 Degrees True.
 *  To calculate this, we need to work out 3 values, refered to in Navigation as A, B, C values.
 *  These are purely numbers with no units, and we only care about the absolute value and "Directions" or "Names", North or South.
 *  
 *  A = Tan(Latitude1)/Tan(dLong) : Named opposite to Latitude1, unless dLong is between 90 and 270 Degrees.
 *  B = Tan(Latitude2)/Sin(dLong) : Always named the same as Latitude2.
 *  C = A +/- B : If A and B are named the same, we add, and C is named the same. If they are different,
 *  we take the difference and C is named after the larger value.
 *  Tan(Initial Course) = 1 / (C * Cos(LatitudeA))
 *  
 *  Vertex - This is the highest position of Latitude that the Great Circle track will reach, and is
 *  always worked out to the same Hemisphere as the starting Latitude. The other vertex can be easily
 *  worked out as the two are diametrically opposed, ie, exactly and opposite.
 *  
 *  Tan(dLong Longitude1 to Vertex) = 1 / (Tan(Initial Course Quadrantal) * Sin(Latitude1))
 *  Cos(Latitude Vertex) = Sin(Initial Course Quadrantal) * Cos(Latitude1)
 * 
 */

 /* TODO
  * Input validation
  * Error checking ie inputs greater than 90 or 180 degrees, perfectly opposite coords
  * Database access - save/load Coordinates
  */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreatCircle
{
    public partial class Form1 : Form
    {
        //These two Enums are simply used to help checks later, and populate windows forms combo boxes.
        private enum hemisphereNS { North, South};
        private enum hemisphereEW { East, West};
        
        //Anngular distance, variables for calculating Initial Course "ic", and the Vertex
        private double dLongDistance;
        private double icAValue;
        private double icBValue;
        private double icCValue;
        private double dLongAV;
        //Distances typically to 1 dp, so we will round later on
        private double totalDistance;

        //Courses typically to 1/2 degree, but will be using integers here
        private int initialCourseQuad;
        private int initialCourseTrue;

        //Directional info
        private hemisphereEW dLongDirection;
        private hemisphereNS icADirection;
        private hemisphereNS icBDirection;
        private hemisphereNS icCDirection;

        //Initializing coordinate structs
        private NavCoords StartCoord = new NavCoords();
        private NavCoords EndCoord = new NavCoords();
        private NavCoords Vertex1Coord = new NavCoords();
        private NavCoords Vertex2Coord = new NavCoords();
        private struct NavCoords
        {
            /* A struct is used here to store variables and methods relating to the coordinates
             * to make things cleaner and easier to follow, and to keep data seperate as I go on             * 
             */

            //Strings containing the original input values, to be worked on
            string latInput;
            string longInput;

            //Hemisphere info
            public hemisphereNS latHemi;
            public hemisphereEW longHemi;

            //Will hold the decimal values of the converted strings, as both Degrees and Radians, for easier calculations
            public double latitudeDeg;
            public double longitudeDeg;
            public double latitudeRad;
            public double longitudeRad;

            /* Coord data must have a latitude and longitude, and both hemispheres
             * Once we have these pieces, just set the other values for use later
             * Keep the values as degrees and radians for ease of use
             */
            public void SetNavCoords(String x, String y, hemisphereNS h1, hemisphereEW h2)
            {
                this.latInput = x;
                this.longInput = y;
                this.latHemi = h1;
                this.longHemi = h2;

                this.latitudeDeg = StringToNumber(latInput);
                this.longitudeDeg = StringToNumber(longInput);

                this.latitudeRad = DegreesToRadians(latitudeDeg);
                this.longitudeRad = DegreesToRadians(longitudeDeg);
            }

            public void SetLatitudeFromRad(double l)
            {
                this.latitudeRad = l;
                this.latitudeDeg = RadiansToDegrees(l);
            }
            
            public void SetLongitudeFromRad(double l)
            {
                this.longitudeRad = l;
                this.longitudeDeg = RadiansToDegrees(l);
            }

            private double StringToNumber(String s)
            {
                /* This function takes the string from the text boxes, in the correct format
                 * and converts it to a decimal value we can use in calculations
                 * eg "20d30m" (20 Degrees 30 Minutes) should become 20.5
                 * 
                 * We run through the string, and each iteration add the character to the temporary string temp
                 * if the character is one of the formatting characters, we convert the temp string to a decimal
                 * corresponding to whether it's degrees/minutes/seconds and clear the string.
                 */
                 
                double d = 0;
                string temp = "";
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == 'd')
                    {
                        d = Convert.ToDouble(temp);
                        temp = "";
                    }
                    else if (s[i] == 'm')
                    {
                        d = d + Convert.ToDouble(temp) / 60;
                        temp = "";
                    }
                    else if (s[i] == 's')
                    {
                        d = d + Convert.ToDouble(temp) / 3600;
                        temp = "";
                    }
                    else
                    {
                        temp = temp + s[i];
                    }
                }

                return d;
            }

            #region Helpers
            //These are simple helper functions to convert between Radians and Degrees, and various simple tasks
            private double RadiansToDegrees(double r)
            {
                return r * (180 / Math.PI);
            }

            private double DegreesToRadians(double d)
            {
                return d / (180 / Math.PI);
            }

            public void ClearData()
            {
                this.latInput = "";
                this.longInput = "";
                this.latHemi = hemisphereNS.North;
                this.longHemi = hemisphereEW.East;
                this.latitudeDeg = 0;
                this.longitudeDeg = 0;
                this.latitudeRad = 0;
                this.longitudeRad = 0;
            }
            #endregion
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            /* Fills the structs with values from user inputs
             * In most cases, using the Enum variables to hemispheres makes things easier,
             * reading and setting values from the drop down boxes needed extra work.
             * We get the selected item, convert to string, parse it, and then cast to the correct variable type.
             */
            Clear();
            StartCoord.SetNavCoords(txtStartLat.Text, txtStartLong.Text, (hemisphereNS)Enum.Parse(typeof(hemisphereNS), cmbStartLatHemi.SelectedItem.ToString()), (hemisphereEW)Enum.Parse(typeof(hemisphereEW), cmbStartLongHemi.SelectedItem.ToString()));
            EndCoord.SetNavCoords(txtEndLat.Text, txtEndLong.Text, (hemisphereNS)Enum.Parse(typeof(hemisphereNS), cmbEndLatHemi.SelectedItem.ToString()), (hemisphereEW)Enum.Parse(typeof(hemisphereEW), cmbEndLongHemi.SelectedItem.ToString()));
            CalculateNav();
            Output();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbStartLatHemi.DataSource = Enum.GetValues(typeof(hemisphereNS));
            cmbEndLatHemi.DataSource = Enum.GetValues(typeof(hemisphereNS));
            cmbStartLongHemi.DataSource = Enum.GetValues(typeof(hemisphereEW));
            cmbEndLongHemi.DataSource = Enum.GetValues(typeof(hemisphereEW));
        }

        private void CalculateNav()
        {
            #region dLongDistance
            /*
             * This section takes the longitude values, as decimals, as well as their respective hemispheres
             * and calculates the distance and which direction to go
             *
             * If the hemispheres are the same, the distance is simply the difference in the two longitudes 
             * if they are different, the distance is (usually) the sum
             * however at this point if the distance is greater than 180 degrees, it is better to go the opposite direction
             * which will be 360 degrees - the previously calculated distance
             */
            if (StartCoord.longHemi == EndCoord.longHemi)
            {
                dLongDistance = Math.Abs(StartCoord.longitudeRad - EndCoord.longitudeRad);
            }
            else
            {
                dLongDistance = StartCoord.longitudeRad + EndCoord.longitudeRad;
                if(dLongDistance > Math.PI)
                {
                    dLongDistance = (2 * Math.PI) - dLongDistance;
                }
            }
            #endregion
            #region dLongDirection
            /*
             * This function determines if we should be going East or West to get to point B
             * 's' is just used as a temporary string
             * 
             * for this function, we need to know the starting/final longitude, the hemispheres, and the distance
             * we check first if we are staying in the same hemisphere
             * if so, are we in the east or west, then evaluate which is greater or farther, then we know the direction
             */
            if (StartCoord.longHemi == EndCoord.longHemi)
            {
                if (StartCoord.longHemi == hemisphereEW.East)
                {
                    if (StartCoord.longitudeRad < EndCoord.longitudeRad)
                    {
                        dLongDirection = hemisphereEW.East;

                    }
                    else
                    {
                        dLongDirection = hemisphereEW.West;
                    }
                }
                else
                {
                    if (StartCoord.longitudeRad > EndCoord.longitudeRad)
                    {
                        dLongDirection = hemisphereEW.East;
                    }
                    else
                    {
                        dLongDirection = hemisphereEW.West;
                    }
                }
            }
            else
            {
                if ((StartCoord.longitudeRad + EndCoord.longitudeRad) > Math.PI)
                {
                    if (StartCoord.longHemi == hemisphereEW.East)
                    {
                        dLongDirection = hemisphereEW.East;
                    }
                    else
                    {
                        dLongDirection = hemisphereEW.West;
                    }
                }
                else
                {
                    if (StartCoord.longHemi == hemisphereEW.East)
                    {
                        dLongDirection = hemisphereEW.West;
                    }
                    else
                    {
                        dLongDirection = hemisphereEW.East;
                    }
                }
            }
            #endregion
            #region TotalDistance
            //If the lattitudes are in the same hemisphere, we add the cos and sin, else we subtract
            if (StartCoord.latHemi == EndCoord.latHemi)
            {
                totalDistance = Math.Round(60 * (180 / Math.PI) * (Math.Acos(Math.Cos(dLongDistance)*Math.Cos(StartCoord.latitudeRad)*Math.Cos(EndCoord.latitudeRad)+Math.Sin(StartCoord.latitudeRad)*Math.Sin(EndCoord.latitudeRad))), 1);
            }
            else
            {
                totalDistance = Math.Round(60 * (180 / Math.PI) * (Math.Acos(Math.Cos(dLongDistance) * Math.Cos(StartCoord.latitudeRad) * Math.Cos(EndCoord.latitudeRad) - Math.Sin(StartCoord.latitudeRad) * Math.Sin(EndCoord.latitudeRad))), 1);
            }
            #endregion
            #region InitialCourse
            /*
             * To calculate the initial course, we need to work out 3 values, known in navigation as A, B, and C values
             * The sign of the value is irrelevant, but the 'name' ie North/South is needed
             */
            icAValue = Math.Abs(Math.Tan(StartCoord.latitudeRad)/Math.Tan(dLongDistance));
            icBValue = Math.Abs(Math.Tan(EndCoord.latitudeRad)/Math.Sin(dLongDistance));

            icBDirection = EndCoord.latHemi; //B always same name as latitude

            //A is named opposite to lattitude, unless dlong between 90 and 270 degrees
            if (dLongDistance > (Math.PI / 2) && dLongDistance < (Math.PI * 1.5))
            {
                icADirection = StartCoord.latHemi;
            }
            else
            {
                if (StartCoord.latHemi == hemisphereNS.North)
                {
                    icADirection = hemisphereNS.South;
                }
                else
                {
                    icADirection = hemisphereNS.North;
                }
            }

            /*If A and B are same names, C is A + B and same direction
            * If different names, ie A is North and B is South, C takes the name of the greater value
            * and takes the value of the difference of A and B
            */
            if (icADirection == icBDirection)
            {
                icCValue = icAValue + icBValue;
                icCDirection = icADirection;
            }
            else
            {
                icCValue = Math.Abs(icAValue - icBValue);
                if (icAValue > icBValue)
                {
                    icCDirection = icADirection;
                }
                else
                {
                    icCDirection = icBDirection;
                }
            }

            /* Tan (Initial Course) = 1 / (C*CosLatA)
            * This gives us the initial course as a Quadrantal ie North 30 Degrees East or South 50 Degrees West
            * So need to convert to Degrees True based on C direction and our DLong direction
            */
            initialCourseQuad = Convert.ToInt32((180 / Math.PI) * (Math.Atan(1 / (icCValue * Math.Cos(StartCoord.latitudeRad)))));
            if (icCDirection == hemisphereNS.North)
            {
                if (dLongDirection == hemisphereEW.East)
                {
                    initialCourseTrue = initialCourseQuad;
                }
                else
                {
                    initialCourseTrue = 360 - initialCourseQuad;
                }
            }
            else
            {
                if (dLongDirection == hemisphereEW.East)
                {
                    initialCourseTrue = 180 - initialCourseQuad;
                }
                else
                {
                    initialCourseTrue = 180 + initialCourseQuad;
                }
            }
            #endregion
            #region Vertex
            /* To calculate the vertex we need the dLong - distance from Start to Vertex
             * We also need to know which hemisphere we are in and direction we are going
             */

            dLongAV = Math.Abs(Math.Atan(1 / (Math.Tan((initialCourseQuad / (180 / Math.PI))) * Math.Sin(StartCoord.latitudeRad))));

            if (StartCoord.latHemi == icCDirection && dLongDirection == StartCoord.longHemi)
            {
                Vertex1Coord.SetLongitudeFromRad(StartCoord.longitudeRad + dLongAV);
            }
            else if (StartCoord.latHemi == icCDirection && dLongDirection != StartCoord.longHemi)
            {
                Vertex1Coord.SetLongitudeFromRad(StartCoord.longitudeRad - dLongAV);
            }
            else if (StartCoord.latHemi != icCDirection && dLongDirection == StartCoord.longHemi)
            {
                Vertex1Coord.SetLongitudeFromRad(StartCoord.longitudeRad - dLongAV);
            }
            else // if(StartCoord.latHemi == icCDirection && dLongDirection != StartCoord.longHemi)
            {
                Vertex1Coord.SetLongitudeFromRad(StartCoord.longitudeRad + dLongAV);
            }

            //Setting an initial hemisphere, can be changed later
            Vertex1Coord.longHemi = hemisphereEW.East;

            //If the longitude is < 0 or > 180 degrees we change the hemisphere
            if (Vertex1Coord.longitudeRad > Math.PI || Vertex1Coord.longitudeRad < 0)
            {
                Vertex1Coord.longitudeRad = Math.Abs(Vertex1Coord.longitudeRad);
                if (Vertex1Coord.longHemi == hemisphereEW.East)
                {
                    Vertex1Coord.longHemi = hemisphereEW.West;
                }
                else
                {
                    Vertex1Coord.longHemi = hemisphereEW.East;
                }
            }

            Vertex1Coord.latHemi = StartCoord.latHemi;
            Vertex1Coord.SetLatitudeFromRad(Math.Acos((Math.Sin(initialCourseQuad / (180 / Math.PI))) * Math.Cos(StartCoord.latitudeRad)));
            #endregion
            #region Vertex2
            /* Set the coordinates for Vertex 2, which are directly opposite the sphere of Vertex 1
             * The value for Latitude will remain the same, but hemisphere is swapped
             * 
             * Longitude hemisphere will also be swapped, but the value will be 180 Degrees - Vertex 1
             * 
             */

            Vertex2Coord.SetLatitudeFromRad(Vertex1Coord.latitudeRad);
            if (Vertex1Coord.latHemi == hemisphereNS.North)
            {
                Vertex2Coord.latHemi = hemisphereNS.South;
            }
            else
            {
                Vertex2Coord.latHemi = hemisphereNS.North;
            }

            Vertex2Coord.SetLongitudeFromRad(Math.PI - Vertex1Coord.longitudeRad);
            if(Vertex1Coord.longHemi == hemisphereEW.East)
            {
                Vertex2Coord.longHemi = hemisphereEW.West;
            }
            else
            {
                Vertex2Coord.longHemi = hemisphereEW.East;
            }
            #endregion
        }
        
        private String DegreesAsString(double deg)
        {
            /* Takes a decimal input and converts it a a human readable string as Degrees and Minutes
             * eg 40.5 Degrees - 40 will be aded to the string, then removed from the decimal
             * we are left with 0.5, which is then multiplied by 60 to give us Minutes
             * then added to the string
             */
            String s = "";
            s = s + (Math.Floor(deg)).ToString() + " Degrees, ";
            deg = (deg - Math.Floor(deg)) * 60;
            s = s + (Math.Floor(deg)).ToString() + " Minutes";
            return s;
        }
        private void Output()
        {
            lblOutDist.Text += + totalDistance + " Nautical Miles | " + Math.Round((totalDistance * 1.15078), 1) + " Statute Miles | " + Math.Round((totalDistance * 1.852), 1) + " Kilometers";
            lblOutCourse.Text += icCDirection + "° " + initialCourseQuad + " " + dLongDirection + "| " + initialCourseTrue + " °T";
            lblOutVert1.Text += DegreesAsString(Vertex1Coord.latitudeDeg) + " " + Vertex1Coord.latHemi + ", " + DegreesAsString(Vertex1Coord.longitudeDeg) + " " + Vertex1Coord.longHemi;
            lblOutVert2.Text += DegreesAsString(Vertex2Coord.latitudeDeg) + " " + Vertex2Coord.latHemi + ", " + DegreesAsString(Vertex2Coord.longitudeDeg) + " " + Vertex2Coord.longHemi;
        }

        private void Clear()
        {
            StartCoord.ClearData();
            EndCoord.ClearData();
            Vertex1Coord.ClearData();
            Vertex2Coord.ClearData();

            lblOutDist.Text = "Total Distance: ";
            lblOutCourse.Text = "Initial Course: ";
            lblOutVert1.Text = "Vertex 1: ";
            lblOutVert2.Text = "Vertex 2: ";
        }
    }
}
