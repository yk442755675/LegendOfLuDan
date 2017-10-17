using UnityEngine;

public class BaseEnemy : Moving
{

    public int Damage;
    public int Health;

    private UnityEngine.Transform target;

    protected override void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        MoveEnemy();
    }

    /// <summary>
    /// 敌人移动
    /// </summary>
    public void MoveEnemy()
    {
        float x = 0;
        float y = 0;
        var xDif = Mathf.Abs(target.position.x - transform.position.x);
        var yDif = Mathf.Abs(target.position.y - transform.position.y);

        if (xDif > 1.5 || yDif > 0.01)
            base.StopMove = false;

        if (xDif > 1.5)
        {
            x = target.position.x > transform.position.x ? 1 : -1;
        }
        else
        {
        }

        if (yDif > 0.01)
        {
            y = target.position.y > transform.position.y ? 0.5f : -0.5f;
        }

        if (x == 0 && y == 0)
            base.StopMove = true;

        Vector3 movement = new Vector3(x, y, 0.0f);
        AutoMove(movement);
        AutoAttack();



    }

}
