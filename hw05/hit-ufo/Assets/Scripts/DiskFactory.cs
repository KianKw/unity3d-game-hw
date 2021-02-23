﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : MonoBehaviour
{
    private List<DiskData> used = new List<DiskData>();   //正在被使用的飞碟列表
    private List<DiskData> free = new List<DiskData>();   //空闲的飞碟列表

    public GameObject GetDisk(int type) {
        GameObject disk_prefab = null;
        //寻找空闲飞碟,如果无空闲飞碟则重新实例化飞碟
        if (free.Count > 0) {
            for(int i = 0; i < free.Count; i++)
            {
                if(free[i].tag == tag)
                {
                    disk_prefab = free[i].gameObject;
                    free.Remove(free[i]);
                    break;
                }
            }
        }

        if(disk_prefab == null) {
            if(type == 1) {
                disk_prefab = Instantiate(
                Resources.Load<GameObject>("Prefabs/disk1"),
                new Vector3(0, -10f, 0), Quaternion.identity);
            }
            else if (type == 2) {
                disk_prefab = Instantiate(
                Resources.Load<GameObject>("Prefabs/disk2"),
                new Vector3(0, -10f, 0), Quaternion.identity);
            }
            else {
                disk_prefab = Instantiate(
                Resources.Load<GameObject>("Prefabs/disk3"),
                new Vector3(0, -10f, 0), Quaternion.identity);
            }
            float ran_x = Random.Range(-1f, 1f) < 0 ? -1 : 1;
            disk_prefab.GetComponent<Renderer>().material.color = disk_prefab.GetComponent<DiskData>().color;
            disk_prefab.GetComponent<DiskData>().direction = new Vector3(ran_x, -10f, 0);
            disk_prefab.transform.localScale = disk_prefab.GetComponent<DiskData>().scale;
        }

        used.Add(disk_prefab.GetComponent<DiskData>());
        return disk_prefab;
    }
    //回收飞碟
    public void FreeDisk(GameObject disk)
    {
        for(int i = 0;i < used.Count; i++)
        {
            if (disk.GetInstanceID() == used[i].gameObject.GetInstanceID())
            {
                used[i].gameObject.SetActive(false);
                free.Add(used[i]);
                used.Remove(used[i]);
                break;
            }
        }
    }
}
