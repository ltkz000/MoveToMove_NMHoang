using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IngameEntityManager : Singleton<IngameEntityManager>
{
    Dictionary<IngameType, List<GameUnit>> ingameEntity = new Dictionary<IngameType, List<GameUnit>>();

    //de cache lai list
    private List<GameUnit> randomList = new List<GameUnit>();

    public void RegisterEntity(GameUnit unit)
    {
        //if (!ingameEntity.ContainsKey(unit.ID))
        //{
        //    ingameEntity[unit.ID] = new List<GameUnit>();
        //}

        //ingameEntity[unit.ID].Add(unit);
    }

    public void UnregisterEntity(GameUnit unit)
    {
        //if (ingameEntity.ContainsKey(unit.ID))
        //{
        //    ingameEntity[unit.ID].Remove(unit);
        //}
    }

    public void ClearMap()
    {
        ingameEntity.Clear();
    }

    public GameUnit GetRandomObject(IngameType ingameType)
    {
        randomList = ingameEntity[ingameType];
        if (randomList.Count > 0)
        {
            return randomList[Random.Range(0, randomList.Count)];
        }
        return null;
    }

    public T GetRandomObject<T>(IngameType ingameType) where T : GameUnit
    {
        return GetRandomObject(ingameType) as T;
    }
    
    public List<GameUnit> GetAllEnemyOnScreen()
    {
        List<GameUnit> baseEnemies = new List<GameUnit>();

        for (int i = 0; i < ingameEntity[IngameType.ENEMY].Count; i++)
        {
            GameUnit baseEnemy = ingameEntity[IngameType.ENEMY][i];
            //if (!baseEnemy.IsOutCamera())
            {
                baseEnemies.Add(baseEnemy);
            }
        }
        return baseEnemies;
    }


    public T GetNearestObject<T>(Vector3 finder, IngameType ingameType) where T : GameUnit
    {
        randomList = ingameEntity[ingameType];

        T nearestCharacter = null;

        if (randomList.Count > 0)
        {
            float nearestDistance = int.MaxValue;
            Vector3 cPos;
            float distance;

            for (int i = 0; i < randomList.Count; i++)
            {
                cPos = randomList[i].TF.position;
                distance = (cPos - finder).sqrMagnitude;
                if (distance < nearestDistance)
                {
                    nearestCharacter = randomList[i] as T;
                    nearestDistance = distance;
                }
            }
        }

        return nearestCharacter;
    }
    public List<T> GetObjectsInRange<T>(Vector3 finder, IngameType ingameType, float minRange = 0, float maxRange = 9999) where T : GameUnit
    {
        List<T> gameunits = new List<T>();
        randomList = ingameEntity[ingameType];

        if (randomList.Count > 0)
        {
            double min = minRange * minRange;
            double max = maxRange * maxRange;

            for (int i = 0; i < randomList.Count; i++)
            {
                Vector3 cPos = randomList[i].TF.position;
                float distance = (cPos - finder).sqrMagnitude;
                if (distance <= max && distance >= min)
                {
                    gameunits.Add(randomList[i] as T);
                }
            }
        }

        return gameunits;
    }

    public List<GameUnit> GetAllEntitiesType(IngameType ingameType)
    {
        if (!ingameEntity.ContainsKey(ingameType))
        {
            ingameEntity[ingameType] = new List<GameUnit>();
        }
        return ingameEntity[ingameType];
    }

    public List<T> GetAllEntitiesType<T>(IngameType ingameType) where T : GameUnit
    {
        List<T> baseEnemies = new List<T>();

        if (ingameEntity.ContainsKey(ingameType))
        {
            for (int i = 0; i < ingameEntity[ingameType].Count; i++)
            {
                T baseEnemy = ingameEntity[ingameType][i] as T;
                baseEnemies.Add(baseEnemy);
            }
        }
        return baseEnemies;
    }

    public bool HasAnyEntity(IngameType ingameType)
    {
        return ingameEntity[ingameType].Count > 0;
    }

}

[System.Serializable]
public class EntityMap<T> : Dictionary<double, T> { }
