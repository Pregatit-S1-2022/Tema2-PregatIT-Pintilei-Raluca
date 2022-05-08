using System;
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks;
using FluentValidation;

namespace Tema2_PregatIT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool debug = true;

          //  SmallApartment mySmallApartament = new SmallApartment(50);
           // SmallApartmentValidator myValidator = new SmallApartmentValidator();

          // myValidator.Validate(mySmallApartment);


            Person myPerson = new Person();

            myPerson.Name = "Jace";
          //  myPerson.House = mySmallApartament;
            myPerson.ShowData();

            if (debug)
                Console.ReadLine();
        }
    }

    class House
    {
        public int area;
        protected Door door;

        public House(int area)
        {
            this.area = area;
            door = new Door();

        }
        public int Area
        {
            get { return area; }
            set { area = value; }
        }
        public Door GetDoor()
        {
            return door;

        }

        public virtual void ShowData()
        {
            Console.WriteLine("I am a house, my area is {0} m2.", area);
        }
    }

    class Door
    {
        protected string color;

        public Door()
        {
            color = "Brown";
        }
        public Door(string color)
        {
            this.color = color;
        }

        public String getColor()
        {
            return color;
        }

        public void setColor(String color)
        {
            this.color = color;
        }

        public void ShowData()
        {
            Console.WriteLine("I am a door, my color is " + color);
        }

    }

    class SmallApartment : House
    {
        public SmallApartment(int area = 50) : base(area)
        {
        }
        public override void ShowData()
        {
            Console.WriteLine("I am an apartment, my area is " +
                area + " m2");
        }
    }

    class Person
    {
        protected string name;
        protected House house;

        public Person()
        {
            name = "Jace";
            house = new House(150);
        }
        public Person(string name, House house)
        {
            this.name = name;
            this.house = house;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public House House
        {
            get { return house; }
            set { house = value; }
        }

        public void ShowData()
        {
            Console.WriteLine("My name is {0}.", name);
            house.ShowData();
            house.GetDoor().ShowData();
        }
        public class SmallApartmentValidator : AbstractValidator<SmallApartment>
        {
            public SmallApartmentValidator()
           {
               RuleFor(x => x.area).InclusiveBetween(0, 50);
           }
        }

      

    }
}
