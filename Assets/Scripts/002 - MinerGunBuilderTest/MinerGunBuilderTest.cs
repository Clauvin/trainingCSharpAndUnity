using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerGunBuilderTest : MonoBehaviour
{
    /// <summary>
    /// MinerGunBuilderTest
    /// 
    /// Draft 1: Gun system similar to Miner Gun Builder basics where
    /// * MinerGun receives a bullet. (Bullets have speed, color, life time, direction and damage)
    /// * MinerGun has connected to it BulletChangers (can change bullets, spit the changed bullet)
    /// * Each BulletChanger spits bullets (or the lack of bullets) to the connected BulletChangers to it
    /// * BulletSpitters spit bullets.
    /// * Spit bullets print the bullet with its data.
    /// 
    /// </summary>

    public delegate Bullet BulletChanger(Bullet bullet);

    public static void bulletCannon(object sender, Bullet bullet, List<BulletChanger> bulletChangers)
    {
        for (int i = 0; i < bulletChangers.Count; i++)
        {
            bullet = bulletChangers[i](bullet);
        }

        Debug.Log("BulletCannonOne " + bullet.ToString());
    }

    class MinerMultipleGun
    {
        //MinerMultipleGun sends bullet to BulletChangers.
        //Each BulletChanger changes bullets and send those
        //Each BulletChanger is an event that changes bullets differently.

        public Bullet current_bullet;
        public EventHandler<Bullet> bulletChangers;

        public List<BulletChanger> listOfBulletChangesOne;
        public List<BulletChanger> listOfBulletChangesTwo;
        public List<BulletChanger> listOfBulletChangesThree;

        public void InitializeBulletChanges()
        {
            listOfBulletChangesOne = new List<BulletChanger>();
            listOfBulletChangesOne.Add((bullet) =>
                {
                    return new Bullet(bullet);
                }
            );
            listOfBulletChangesOne.Add((bullet) =>
                {
                    bullet.damage += 1.0f;
                    return bullet;
                }
            );

            listOfBulletChangesTwo = new List<BulletChanger>();
            listOfBulletChangesTwo.Add((bullet) =>
                {
                    return new Bullet(bullet);
                }
            );
            listOfBulletChangesTwo.Add((bullet) =>
                {
                    bullet.damage += 10.0f;
                    return bullet;
                }
            );

            listOfBulletChangesThree = new List<BulletChanger>();
        }

        public void SetUpBulletChangers()
        {
            bulletChangers += (sender, bullet) => MinerGunBuilderTest.bulletCannon(sender, bullet, listOfBulletChangesOne);
            bulletChangers += (sender, bullet) => MinerGunBuilderTest.bulletCannon(sender, bullet, listOfBulletChangesTwo);
            bulletChangers += (sender, bullet) => MinerGunBuilderTest.bulletCannon(sender, bullet, listOfBulletChangesThree);
        }

        public Bullet applyBulletChangers(Bullet bullet)
        {
            return bullet;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Bullet newBullet = new Bullet();
        MinerMultipleGun multipleGun = new MinerMultipleGun();

        multipleGun.InitializeBulletChanges();
        multipleGun.SetUpBulletChangers();
        multipleGun?.bulletChangers.Invoke(this, newBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
