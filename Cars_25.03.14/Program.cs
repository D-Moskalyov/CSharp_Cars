using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Cars_25._03._14
{
    class MyEventArgs : EventArgs
    {
        public int k;
        public string type;
        public int numb;
    }
    delegate void SpeedUpHandler(object source, MyEventArgs arg);
    delegate void SpeedDownHandler(object source, MyEventArgs arg);
	delegate void FinishHandler();
    class MySpeedUpEvent
    {
        public event SpeedUpHandler SpeedUpEvent;
        public void OnSpeedUpEvent(int k, string className, int num)
        {
            MyEventArgs arg = new MyEventArgs();
            if (SpeedUpEvent != null)
            {
				arg.type = className;
				arg.numb = num;
                arg.k = k;
                SpeedUpEvent(this, arg);
            }
        }
    }
    class MySpeedDownEvent
    {
        public event SpeedDownHandler SpeedDownEvent;
        public void OnSpeedUpEvent(int k, string className, int num)
        {
            MyEventArgs arg = new MyEventArgs();
            if (SpeedDownEvent != null)
            {
                arg.type = className;
				arg.numb = num;
                arg.k = k;
                SpeedDownEvent(this, arg);
            }
        }
    }
	class MyFinishEvent
    {
        public event FinishHandler FinishEvent;
        public void OnFinishEvent()
        {
            if (FinishEvent != null)
            {
                FinishEvent();
            }
        }
    }
    interface Car
    {
        /*protected int maxspeed;
        protected int speed;
		private int number;
        private int distance;*/
        int Distance
        {
            get;
            set;
        }
        int Number
        {
            get;
            set;
        }
        void ChangeSpeed(object source, MyEventArgs arg);
		void Finish();
        //virtual public void DownSpeed(object source, MyEventArgs arg);
    }
    class Sport : Car
    {
        private int maxspeed;
        private int speed;
        private int number;
        private int distance;
		public  int numb = 0;
        public Sport()
        {
            maxspeed = 200;
            speed = 0;
            Distance = 0;
			Number = (numb++);
        }
        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }
		public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public void ChangeSpeed(object source, MyEventArgs arg)
        {
			if(arg.numb == Number && arg.type == GetType().Name)
			{
				if ((string)source == "MySpeedUpEvent")
				{
					speed = speed + (arg.k * 20);
					if (speed > maxspeed)   speed = maxspeed;
				}
				if ((string)source == "MySpeedDownEvent")
				{
					speed = speed - (arg.k * 20);
					if (speed < 1)    speed = 1;
				}
			}
        }
		public void Finish()
        {
            speed = 0;
            Distance = 0;
        }
        //public override void DownSpeed(object source, MyEventArgs arg)
        //{
        //    speed = speed - (arg.k * 20);
        //}
    }
    class Passenger : Car
    {
        private int maxspeed;
        private int speed;
        private int number;
        private int distance;
		static int numb = 0;
        public Passenger()
        {
            maxspeed = 150;
            speed = 0;
            Distance = 0;
			Number = (numb++);
        }
        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public void ChangeSpeed(object source, MyEventArgs arg)
        {
            if (arg.numb == Number && arg.type == GetType().Name)
			{
				if ((string)source == "MySpeedUpEvent")
				{
					speed = speed + (arg.k * 15);
					if (speed > maxspeed) speed = maxspeed;
				}
				if ((string)source == "MySpeedDownEvent")
				{
					speed = speed - (arg.k * 15);
					if (speed < 1) speed = 1;
				}
			}
        }
		public void Finish()
        {
            speed = 0;
            Distance = 0;
        }
        //public override void DownSpeed(object source, MyEventArgs arg)
        //{
        //    speed = speed - (arg.k * 15);
        //}
    } 
    class Bus : Car
    {
        private int maxspeed;
        private int speed;
        private int number;
        private int distance;
		static int numb = 0;
        public Bus()
        {
            maxspeed = 100;
            speed = 0;
            Distance = 0;
			Number = (numb++);
        }
        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public void ChangeSpeed(object source, MyEventArgs arg)
        {
            if (arg.numb == Number && arg.type == GetType().Name)
			{
				if ((string)source == "MySpeedUpEvent")
				{
					speed = speed + (arg.k * 10);
					if (speed > maxspeed) speed = maxspeed;
				}
				if ((string)source == "MySpeedDownEvent")
				{
					speed = speed - (arg.k * 10);
					if (speed < 1) speed = 1;
				}
			}
        }
		public void Finish()
        {
            speed = 0;
            Distance = 0;
        }
        //public override void DownSpeed(object source, MyEventArgs arg)
        //{
        //    speed = speed - (arg.k * 5);
        //}
    }
    class Truck : Car
    {
        private int maxspeed;
        private int speed;
        private int number;
        private int distance;
		static int numb = 0;
        public Truck()
        {
            maxspeed = 80;
            speed = 0;
            Distance = 0;
			Number = (numb++);
        }
        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public void ChangeSpeed(object source, MyEventArgs arg)
        {
            if (arg.numb == Number && arg.type == GetType().Name)
			{
				if ((string)source == "MySpeedUpEvent")
				{
					speed = speed + (arg.k * 5);
					if (speed > maxspeed) speed = maxspeed;
				}
				if ((string)source == "MySpeedDownEvent")
				{
					speed = speed - (arg.k * 5);
					if (speed < 1) speed = 1;
				}
			}
        }
		public void Finish()
        {
            speed = 0;
            Distance = 0;
        }
        //public override void DownSpeed(object source, MyEventArgs arg)
        //{
        //    speed = speed - (arg.k * 10);
        //}
    }
    class Program
    {
		static bool IsFinish(Car[][] crs, int dst)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if( crs[i][j].Distance == dst )
						return true;
				}
			}
			return false;
		}
        static void Show()
        {
        }
        static void Main(string[] args)
        {
            //Console.SetWindowSize(100, 80);
            int dist = 500;
            int[,] players = new int[4, 2];
            Random rand = new Random();
            Sport sp = new Sport();
            MySpeedUpEvent up = new MySpeedUpEvent();
            MySpeedDownEvent down = new MySpeedDownEvent();
            MyFinishEvent finish = new MyFinishEvent();
            Car[][] cars = new Car[4][];
            cars[0] = new Sport[4];
            cars[1] = new Passenger[4];
            cars[2] = new Bus[4];
            cars[3] = new Truck[4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    finish.FinishEvent += cars[i][j].Finish;
                }
            }
            do
            {
                for (int i = 0; i < 4; i++)
                {
                    players[i, 0] = rand.Next() % 4;
                    players[i, 1] = rand.Next() % 4;
                }
                bool unic = true;
                do
                {
                    unic = true;
                    for (int i = 0; i < 3; i++)
                    {
                        if (players[i, 0] == players[i + 1, 0])
                        {
                            if (players[i, 1] == players[i + 1, 1])
                            {
                                players[i, 1] = (players[i, 1] + 1) % 4;
                                unic = false;
                            }
                        }
                    }
                } while (!unic);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        up.SpeedUpEvent += cars[i][j].ChangeSpeed;
                        down.SpeedDownEvent += cars[i][j].ChangeSpeed;
                    }
                }
                while (!IsFinish(cars, dist))
                {
                    //продвижение
                    Show();
                    Thread.Sleep(10);
                }
                Thread.Sleep(5000);
                finish.OnFinishEvent();
            } while (true);
        }
    }
}

/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_25._03._14
{
    class MyEventArgs : EventArgs
    {
        public int k;
    }
    delegate void SpeedUpHandler(object source, MyEventArgs arg);
    //delegate void SpeedDownHandler(object source, MyEventArgs arg);
    class MySpeedUpEvent
    {
        public event SpeedUpHandler SpeedUpEvent;
        public void OnSpeedUpEvent(int k)
        {
            MyEventArgs arg = new MyEventArgs();
            if (SpeedUpEvent != null)
            {
                arg.k = k;
                SpeedUpEvent(this, arg);
            }
        }
    }
    class MySpeedDownEvent
    {
        public event SpeedUpHandler SpeedDownEvent;
        public void OnSpeedUpEvent(int k)
        {
            MyEventArgs arg = new MyEventArgs();
            if (SpeedDownEvent != null)
            {
                arg.k = k;
                SpeedDownEvent(this, arg);
            }
        }
    }
    abstract class Car
    {
        protected int maxspeed;
        protected int speed;
        private int distance;
        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        abstract public void UpSpeed(object source, MyEventArgs arg);
        abstract public void DownSpeed(object source, MyEventArgs arg);
    }
    class Sport : Car
    {
        public Sport()
        {
            maxspeed = 200;
            speed = 0;
            Distance = 0;
        }
        public override void UpSpeed(object source, MyEventArgs arg)
        {
            if(source == "MySpeedUpEvent")
            speed = speed + (arg.k * 20);
        }
        public override void DownSpeed(object source, MyEventArgs arg)
        {
            speed = speed - (arg.k * 20);
        }
    }
    class Passenger : Car
    {
        public Passenger()
        {
            maxspeed = 150;
            speed = 0;
            Distance = 0;
        }
        public override void UpSpeed(object source, MyEventArgs arg)
        {
            speed = speed + (arg.k * 15);
        }
        public override void DownSpeed(object source, MyEventArgs arg)
        {
            speed = speed - (arg.k * 15);
        }
    }
    class Truck : Car
    {
        public Truck()
        {
            maxspeed = 80;
            speed = 0;
            Distance = 0;
        }
        public override void UpSpeed(object source, MyEventArgs arg)
        {
            speed = speed + (arg.k * 10);
        }
        public override void DownSpeed(object source, MyEventArgs arg)
        {
            speed = speed - (arg.k * 10);
        }
    }
    class Bus : Car
    {
        public Bus()
        {
            maxspeed = 100;
            speed = 0;
            Distance = 0;
        }
        public override void UpSpeed(object source, MyEventArgs arg)
        {
            speed = speed + (arg.k * 5);
        }
        public override void DownSpeed(object source, MyEventArgs arg)
        {
            speed = speed - (arg.k * 5);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bus bus = new Bus();
            
            
        }
    }
}*/