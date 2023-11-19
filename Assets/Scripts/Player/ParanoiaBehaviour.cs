using UnityEngine;

public class ParanoiaBehaviour : MonoBehaviour
{
    [SerializeField] int MaxParanoiaLevel = 10;
    [SerializeField] int MaxParanoiaTick = 10;
    [SerializeField] int MaxRehabTick = 3;
    private int CurrentParanoiaTick = 0;
    public int CurrentParanoiaLevel = 0;
    private int CurrentRehabTick = 0;

    private void FixedUpdate()
    {
        if (!GameManager.Instance)
        {
            return;
        }
        
        if (GameManager.Instance.lightingOn)
        {
            RehabTickUpdate();
        }
        else
        {
            ParanoiaTickUpdate();
        }
    }

    void RehabTickUpdate()
    {
        this.CurrentRehabTick++;
        if (this.CurrentRehabTick < this.MaxRehabTick)
        {
            return;
        }

        this.CurrentRehabTick = 0;

        if (this.CurrentParanoiaLevel != 0)
        {
            this.CurrentParanoiaLevel--;
        }
    }

    void ParanoiaTickUpdate()
    {
        this.CurrentParanoiaTick++;
        if (this.CurrentParanoiaTick < this.MaxParanoiaTick)
        {
            return;
        }

        this.CurrentParanoiaTick = 0;
        
        if (this.CurrentParanoiaLevel >= this.MaxParanoiaLevel)
        {
            return;
        }
        this.CurrentParanoiaLevel++;
    }
}
