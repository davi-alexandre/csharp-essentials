using System;
using System.Collections.Generic;
using static System.Console;

/*
    In general, method references are the only cases where it is advisable to work 
        with a delegate variable outside the context of an event
    In other words, given the additional encapsulation features of an event and the 
        ability to customize the implementation when necessary, the best practice is 
        always to use events for the observer pattern
*/

namespace Two.Events
{
    class Cooler
    {
        public Cooler(float temperature)
        {
            Temperature = temperature;
        }
        public float Temperature { get; set; }


        public void OnTemperatureChanged(float newTemperature)
        {
            if (newTemperature > Temperature)
                WriteLine("Cooler: On");
            else
                WriteLine("Cooler: Off");
        }
    }

    class Heater
    {
        public Heater(float temperature)
        {
            Temperature = temperature;
        }
        public float Temperature { get; set; }


        public void OnTemperatureChanged(float newTemperature)
        {
            if (newTemperature < Temperature)
                WriteLine("Heater: On");
            else
                WriteLine("Heater: Off");
        }
    }

    class Thermostat
    {
        public Action<float> OnTemperatureChange { get; set; }

        public float CurrentTemperature
        {
            get { return _CurrentTemperature; }
            set
            {
                if (value != CurrentTemperature)
                {
                    _CurrentTemperature = value;

                    //OnTemperatureChange?.Invoke(value);
                    Action<float> onTemperatureChange = OnTemperatureChange; // Thread-Safe
                    if (onTemperatureChange != null)
                    {
                        var exceptionCollection = new List<Exception>();
                        foreach (Action<float> handler in onTemperatureChange.GetInvocationList())
                        {
                            try
                            {
                                handler(value);
                            }
                            catch (Exception e)
                            {
                                exceptionCollection.Add(e);
                            }
                        }

                        if (exceptionCollection.Count > 0)
                        {
                            throw new AggregateException("There were exceptions"+
                                "thrown by OnTemperatureChange Event subscribers", exceptionCollection);
                            // Without error handling, if a subscriber throws an
                            // exception the other handlers don't get to execute
                        }
                    }
                }
            }
        }
        private float _CurrentTemperature;
    }

    class TheObserverStarter
    {
        public static void Start()
        {
            Thermostat thermostat = new Thermostat();
            Heater heater = new Heater(60);
            Cooler cooler = new Cooler(80);

            thermostat.OnTemperatureChange += heater.OnTemperatureChanged;
            thermostat.OnTemperatureChange += cooler.OnTemperatureChanged;

            Write("Enter temperature: ");
            string temperature = ReadLine();
            thermostat.CurrentTemperature = float.Parse(temperature);
        }
    }
}