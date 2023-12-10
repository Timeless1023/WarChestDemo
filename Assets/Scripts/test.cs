using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class test : MonoBehaviour
{
     public Tilemap tilemap;
     public TileBase tile;
     List<Vector3Int> aroundOfClick = new List<Vector3Int>();
     public Sprite sm;

    // Start is called before the first frame update
    void Start()
    {
        //tilemap = transform.parent.GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        mapclick();
    }

    void mapclick()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Vector3Int cellPosition = tilemap.WorldToCell(transform.position);
        //     Color co = tilemap.GetColor(cellPosition);
        //     print("鼠标左键被按下！");
        //     print(co);
        //     print(cellPosition);

        //     //TileBase tile = tilemap.GetTile(new Vector3Int(0, 1, 0));

        //     print(tilemap.GetTile(new Vector3Int(0, 1, 0)));

        //     tilemap.SetColor( new Vector3Int(0, 1, 0), Color.red );

        //     var position = new Vector3Int( 0, 1, 0 );
        //     tilemap.SetTile( position, tile );
        // }


        // 检测鼠标左键点击
        if (Input.GetMouseButtonDown(0))
        {
            // 获取鼠标位置
            Vector3 mousePosition = Input.mousePosition;

            // 将屏幕坐标转换为世界坐标
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // 发射射线检测是否点击到Tilemap
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Board"))
            {
                // 将世界坐标转换为Tilemap坐标
                Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);

                // 在这里处理点击到Tilemap的情况
                Debug.Log("点击到瓦片坐标：" + cellPosition);

                // sm.transform.position = cellPosition;

                // if (aroundOfClick.Count > 0) {
                //     foreach (Vector3Int tilePos in aroundOfClick) {
                //         // tilemap.SetColor( tilePos, Color.red );
                //         tilemap.SetTile( tilePos, null );
                //         Debug.Log("周围瓦片坐标：" + tilePos);
                //     }

                //     aroundOfClick.Clear();
                // }

                aroundOfClick.Add(new Vector3Int(cellPosition.x + 1, cellPosition.y, 0));
                aroundOfClick.Add(new Vector3Int(cellPosition.x, cellPosition.y + 1, 0));
                aroundOfClick.Add(new Vector3Int(cellPosition.x - 1, cellPosition.y + 1, 0));
                aroundOfClick.Add(new Vector3Int(cellPosition.x - 1, cellPosition.y, 0));
                aroundOfClick.Add(new Vector3Int(cellPosition.x - 1, cellPosition.y - 1, 0));
                aroundOfClick.Add(new Vector3Int(cellPosition.x, cellPosition.y - 1, 0));

                foreach (Vector3Int tilePos in aroundOfClick) {
                    // tilemap.SetColor( tilePos, Color.red );

                    // 设置瓦片颜色
                    tilemap.SetTileFlags(cellPosition, TileFlags.None);  // 清除之前的标志
                    tilemap.SetColor(cellPosition, Color.red);  // 这里设置为红色，你可以根据需要调整颜色
                    // tilemap.SetTile( tilePos, tile );
                    Debug.Log("周围瓦片坐标：" + tilePos);
                }

                
            }
        }
    }
}
