using UnityEngine;

public class TestUshort : MonoBehaviour
{
    public ushort arg = 0;
    public ushort result = ushort.MaxValue;

    private void OnValidate()
    {
        result += arg;
    }
}
