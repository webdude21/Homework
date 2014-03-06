
using System;
using GeometryAPI;

namespace AcademyGeometry
{
    internal class AdvancedFigureController : FigureController
    {
        public override void ExecuteFigureCreationCommand(string[] splitFigString)
        {
            switch (splitFigString[0])
            {
                case "circle":
                    {
                        Vector3D o = Vector3D.Parse(splitFigString[1]);
                        double r = double.Parse(splitFigString[2]);
                        this.currentFigure = new Circle(o, r);
                        break;
                    }
                case "cylinder":
                    {
                        Vector3D top = Vector3D.Parse(splitFigString[1]);
                        Vector3D bottom = Vector3D.Parse(splitFigString[2]);
                        double radius = double.Parse(splitFigString[3]);
                        this.currentFigure = new Cylinder(top, bottom, radius);
                        break;
                    }
                default:
                    base.ExecuteFigureCreationCommand(splitFigString);
                    break;
            }

            this.EndCommandExecuted = false;
        }

        protected override void ExecuteFigureInstanceCommand(string[] splitCommand)
        {
            switch (splitCommand[0])
            {
                case "area":
                    {
                        var areaMeasurable = this.currentFigure as IAreaMeasurable;
                        if (areaMeasurable != null)
                        {
                            Console.WriteLine("{0:0.00}", areaMeasurable.GetArea());

                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                    }
                    break;
                case "normal":
                    {
                        var areaMeasurable = this.currentFigure as IFlat;
                        if (areaMeasurable != null)
                        {
                            Console.WriteLine(areaMeasurable.GetNormal());

                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                    }
                    break;
                case "volume":
                    {
                        var currentAsVolumeMeasurable = this.currentFigure as IVolumeMeasurable;
                        if (currentAsVolumeMeasurable != null)
                        {
                            Console.WriteLine("{0:0.00}", currentAsVolumeMeasurable.GetVolume());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }
                default:
                    base.ExecuteFigureInstanceCommand(splitCommand);
                    break;
            }
        }
    }
}
