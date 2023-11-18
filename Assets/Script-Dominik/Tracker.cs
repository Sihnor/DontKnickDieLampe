//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Tracker : MonoBehaviour
//{
//    class Program
//    {
//        // Define a class to represent the game object.
//        class GameObject
//        {
//            public string Name { get; set; }
//            public int X { get; set; }
//            public int Y { get; set; }
//            public int Z { get; set; }
//        }

//        //Define a class to tracker the specific object in the Game.
//        class ObjectTracker
//        {
//            private GameObject trackedObject;

//            //Constructor to initialize the ObjectTracker with the game object to track.
//            public ObjectTracker(GameObject gameObject)
//            {
//                trackedObject = gameObject;
//            }
//            //Method to update the Position of the tracked obejct.
//            public void UpdatePosition(int x, int y, int z)
//            {
//                trackedObject.X = x;
//                trackedObject.Y = y;
//                trackedObject.Z = z;
//                //Log the position of the tracked object.
//                Console.WriteLine($"position of {trackedObject.Name} updated to ({x},{y},{z})");
//            }
//        }

//        //Entry point of the program.
//        static void Main(string[] args)
//        {
//            //Create a game object to tracker.
//            GameObject gameObject = new GameObject
//            {
//                Name = "Player",
//                X = 0,
//                Y = 0,
//                Z = 0
//            };
//            //Create an Object tracker for the game object.
//            ObjectTracker objectTracker = new ObjectTracker(gameObject);

//            //Prompt the user for input.
//            Console.WriteLine("Enter the New position of the object (x, y, z):");
//            Console.Write("x: ");
//            int x = int.Parse(Console.ReadLine());
//            Console.Write("y: ");
//            int y = int.Parse(Console.ReadLine());
//            Console.Write("z: ");
//            int z = int.Parse(Console.ReadLine());
//            //Surround the Code with a try-catch block to handle potential expections gracefully.
//            try
//            {
//                // Call the UpdatePosition method of the object tracker to update the position of the tracked object.
//                objectTracker.UpdatePosition(x, y, z);
//            }
//            // Catch any exceptions thrown by the UpdatePosition method or any other exceptions in the try block.
//            catch (Exception ex)
//            {
//                // Print the error message to the console.
//                Console.WriteLine($"Error: {ex.Message}");
//            }
//        }
//        // Start is called before the first frame update
//        void Start()
//        {

//        }

//        // Update is called once per frame
//        void Update()
//        {

//        }
//    }
//}
