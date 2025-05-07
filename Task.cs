using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public float pct = 0f;
    public GameObject powerbox;
    public GameObject doneVersion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit laserImpactReport = new RaycastHit();

        if (Physics.Raycast(laser, out laserImpactReport, 5f))
        {
            if (Input.GetMouseButton(0) && laserImpactReport.transform.gameObject == powerbox)
            {
                pct += 0.01f;
                if (pct > 1f)
                {
                    Destroy(laserImpactReport.transform.gameObject);
                    doneVersion.SetActive(true);
                }
                laserImpactReport.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }

    }
}