using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://kata-log.rocks/mars-rover-kata
//For the sake of training for live coding, Mars is a rectangle with wrapping this time. -_-
public class MarsScriptingKata : MonoBehaviour
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public class MarsLimits
    {
        public int minX, maxX;
        public int minY, maxY;
        public Vector2Int[] obstacles;

        public MarsLimits(int minX, int maxX, int minY, int maxY, Vector2Int[] obstacles)
        {
            this.minX = minX; this.maxX = maxX;
            this.minY = minY; this.maxY = maxY;
            this.obstacles = obstacles;
        }
    }

    public class MarsRoverData
    {
        MarsLimits marsLimits;

        int x, y;
        Direction direction;
        string commandArray;

        public MarsRoverData(int x, int y, Direction direction, MarsLimits marsLimits)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;

            this.marsLimits = marsLimits;
        }

        public void setCommandArray(string array)
        {
            commandArray = array;
        }
        
        public string getCommandArray()
        {
            return commandArray;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

       
        public Vector2Int executeCommandArray()
        {
            Vector2Int collision_check;

            for (int i = 0; i < commandArray.Length; i++)
            {
                collision_check = executeCommandFromArray(i);
                if (collision_check != new Vector2Int(0, 0))
                {
                    Debug.LogError(collision_check);
                    return collision_check;
                }
            }

            return new Vector2Int(0, 0);
        }

        public Vector2Int executeCommandFromArray(int i)
        {
            string command = commandArray[i].ToString();
            //forward = f
            if (command == "f") return moveForward();

            //backward = b;
            if (command == "b") return moveBackward();

            //turn left = l
            if (command == "l")
            {
                turnLeft();
                return new Vector2Int(0, 0);
            }

            //turn right = r
            if (command == "r")
            {
                turnRight();
                return new Vector2Int(0, 0);
            }

            return new Vector2Int(0, 0);
        }


        public Vector2Int moveForward()
        {
            int new_x = x;
            int new_y = y;

            switch (direction)
            {
                case Direction.North:
                    new_y += 1;
                    new_y = fixWrappingOnVerticalEdges(new_y);
                    break;

                case Direction.East:
                    new_x += 1;
                    new_x = fixWrappingOnHorizontalEdges(new_x);
                    break;

                case Direction.South:
                    new_y -= 1;
                    new_y = fixWrappingOnVerticalEdges(new_y);
                    break;

                case Direction.West:
                    new_x -= 1;
                    new_x = fixWrappingOnHorizontalEdges(new_x);
                    break;

                default:
                    break;
            }

            Vector2Int checkCollision = checkForCollision(new Vector2Int(new_x, new_y));

            if (checkCollision == new Vector2Int(0, 0))
            {
                x = new_x;
                y = new_y;
                return new Vector2Int(0, 0);
            }
            else
            {
                return new Vector2Int(new_x, new_y);
            }

            return new Vector2Int(0, 0);
        }

        public Vector2Int moveBackward()
        {
            int new_x = x;
            int new_y = y;

            switch (direction)
            {
                case Direction.North:
                    new_y -= 1;
                    new_y = fixWrappingOnVerticalEdges(new_y);
                    break;

                case Direction.East:
                    new_x -= 1;
                    new_x = fixWrappingOnHorizontalEdges(new_x);
                    break;

                case Direction.South:
                    new_y += 1;
                    new_y = fixWrappingOnVerticalEdges(new_y);
                    break;

                case Direction.West:
                    new_x += 1;
                    new_x = fixWrappingOnHorizontalEdges(new_x);
                    break;

                default:
                    break;
            }

            Vector2Int checkCollision = checkForCollision(new Vector2Int(new_x, new_y));

            if (checkCollision == new Vector2Int(0, 0))
            {
                x = new_x;
                y = new_y;
                return new Vector2Int(0, 0);
            }
            else
            {
                return new Vector2Int(new_x, new_y);
            }

            return new Vector2Int(0, 0);
        }

        public int fixWrappingOnHorizontalEdges(int testingX)
        {
            if (testingX < marsLimits.minX) return marsLimits.maxX;
            if (testingX > marsLimits.maxX) return marsLimits.minX;
            return testingX;
        }

        public int fixWrappingOnVerticalEdges(int testingY)
        {
            if (y < marsLimits.minY) return marsLimits.maxY;
            if (y > marsLimits.maxY) return marsLimits.minY;
            return testingY;
        }

        public Vector2Int checkForCollision(Vector2Int futurePosition)
        {
            for (int i = 0; i < marsLimits.obstacles.Length; i++)
            {
                Debug.Log(futurePosition.Equals(marsLimits.obstacles[i]));
                if (futurePosition.Equals(marsLimits.obstacles[i]))
                {
                    return marsLimits.obstacles[i];
                }
            }
            return new Vector2Int(0, 0);
        }

        public void turnLeft()
        {
            switch (direction)
            {
                case Direction.North:
                    direction = Direction.West;
                    break;

                case Direction.East:
                    direction = Direction.North;
                    break;

                case Direction.South:
                    direction = Direction.East;
                    break;

                case Direction.West:
                    direction = Direction.South;
                    break;

                default:
                    break;
            }
        }

        public void turnRight()
        {
            switch (direction)
            {
                case Direction.North:
                    direction = Direction.East;
                    break;

                case Direction.East:
                    direction = Direction.South;
                    break;

                case Direction.South:
                    direction = Direction.West;
                    break;

                case Direction.West:
                    direction = Direction.North;
                    break;

                default:
                    break;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
