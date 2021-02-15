public class Enemy
{
    public string name;
    float moveSpeed = 3.5f;
    float xSize = 0f;

    public Enemy(float newSpeed,float newSize){
        moveSpeed = newSpeed;
        xSize = newSize;
    }

    public float MoveSpeed{
        get {
            return moveSpeed;
        }
    }

    public float XSize{
        get{
            return xSize;
        }
    }
}
