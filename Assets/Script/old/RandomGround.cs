using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomGround : MonoBehaviour
{
    public Transform player;
    public List<GameObject> ground; //Danh sách các miếng đất đã vẽ
    public List<GameObject> groundOld; //Danh sách các miếng đất đã sinh ra

    private Vector2 nextPos;
    private Vector2 endPos;

    private float rd;
    private int id;
    private int groundLen; //độ dài miếng đất

    // Start is called before the first frame update
    private void Start()
    {
        endPos = new Vector2(27f, 0f);//Vị trí cuối cùng của map hiện tại là 27 do ô đất dài 27 ô

        //Cho đoạn code bên dưới vào 1 vòng lặp khoảng 5 lần để tạo ra 5 miếng đất

        for (int i = 0; i < 5; i++)
        {
            rd = Random.Range(2f, 5f); //Random khoảng cách giữa miếng đất đầu và miếng tiếp theo
            nextPos = new Vector2(endPos.x + rd, 0f);//Vị trí đặt miếng đất tiếp theo = Vị trí cuối + khoảng cách random được
            id = Random.Range(0, ground.Count);//Random miếng đất sẽ sinh ra
            GameObject newGround = Instantiate(ground[id], nextPos, Quaternion.identity, transform);//Sinh ra miếng đất với ID vừa random được, tại vị trí nextPos, không quay, là con của đối tượng hiện tại (grid)
            groundOld.Add(newGround);//Thêm miếng đất vừa tạo vào danh sách
            //Tiếp theo, kiểm tra xem miếng đất vừa sinh ra có độ dài bao nhiêu
            switch (id)
            {
                case 0: groundLen = 6; break;
                case 1: groundLen = 12; break;
                case 2: groundLen = 16; break;
                case 3: groundLen = 17; break;
                case 4: groundLen = 21; break;
                case 5: groundLen = 27; break;
            }

            endPos = new Vector2(nextPos.x + groundLen, 0f);
        }        
    }

    // Update is called once per frame
    private void Update()
    {
        //Bây giờ, chúng ta viết vào phương thức Update để nó liên tục kiểm tra
        //Xem vị trí của người chơi so với điểm endPos cách nhau bao xa
        //Nếu khoảng cách nhỏ hơn 100f thì chúng ta tiếp tục tạo ra các miếng đất tiếp theo
        if(Vector2.Distance(player.position, endPos) < 100f)
        {
            for (int i = 0; i < 5; i++)
            {
                rd = Random.Range(2f, 5f); //Random khoảng cách giữa miếng đất đầu và miếng tiếp theo
                nextPos = new Vector2(endPos.x + rd, 0f);//Vị trí đặt miếng đất tiếp theo = Vị trí cuối + khoảng cách random được
                id = Random.Range(0, ground.Count);//Random miếng đất sẽ sinh ra
                GameObject newGround = Instantiate(ground[id], nextPos, Quaternion.identity, transform);//Sinh ra miếng đất với ID vừa random được, tại vị trí nextPos, không quay, là con của đối tượng hiện tại (grid)
                groundOld.Add(newGround);
                //Tiếp theo, kiểm tra xem miếng đất vừa sinh ra có độ dài bao nhiêu
                switch (id)
                {
                    case 0: groundLen = 6; break;
                    case 1: groundLen = 12; break;
                    case 2: groundLen = 16; break;
                    case 3: groundLen = 17; break;
                    case 4: groundLen = 21; break;
                    case 5: groundLen = 27; break;
                }

                endPos = new Vector2(nextPos.x + groundLen, 0f);
            }
        }

        //Nhân vật chạy qua nhưng các miếng đất cũ không mất đi, chúng ta  cần viết tiếp 

        //Lấy ra miếng đất đầu tiên trong danh sách
        GameObject getOneGround = groundOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(player.position, getOneGround.transform.position) > 100f)
        {
            //Nếu khoảng cách giữa người chơi và miếng đất vừa lấy ra lớn hơn 100
            groundOld.Remove(getOneGround);//Xóa nó khỏi danh sách
            Destroy(getOneGround);//Hủy gameObject
        }
    }
}