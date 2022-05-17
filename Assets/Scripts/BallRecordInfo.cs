using System;
using System.Collections.Generic;
using UnityEngine;

class CollisionEvent
{
    public int frame;
    public int id;
}

class BallPath
{
    public int from;
    public int to;
    public List<int> posistion;
    public List<CollisionEvent> events;
}
