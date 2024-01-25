using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Npc_State
{
    public class PoolingManager : MonoBehaviour
    {
        public static PoolingManager Instance;

        public List<PoolingObject> poolingObjects;
        private Dictionary<string, List<GameObject>> _objectPool;
        
        void Awake()
        {
            Instance = this;
            _objectPool = new Dictionary<string, List<GameObject>>();
        }

        // Update is called once per frame
        public GameObject Get(string objectName)
        {
            //1. 이미 만들어진 오브젝트 있는지 확인
            if(!_objectPool.ContainsKey(objectName))//오브젝트 풀에 키값 있는지 확인(없을경우)
            {
                var prefabToInstantiate = poolingObjects.FirstOrDefault(obj => obj.name == objectName);
                _objectPool.Add(objectName, new List<GameObject>());

                var instance = Instantiate(prefabToInstantiate.prefab);
                _objectPool[objectName].Add(instance);

                return instance;
            }
            else //관리 키 값이 있다면
            {
                //사용할 수 있는 게임오브젝트 찾기
                var possibleGameObject = _objectPool[objectName].FirstOrDefault(obj => obj.activeInHierarchy == false);

                if (possibleGameObject != null) return possibleGameObject;
                else
                {
                    var prefabToInstantiate = poolingObjects.FirstOrDefault(obj => obj.name == objectName);
                    var newGameObject = Instantiate(prefabToInstantiate.prefab);
                    _objectPool[objectName].Add(newGameObject);
                }
            }
            //2. 찾은 오브젝트 없을경우 새로 생성해 반환
            //3. 만약 오브젝트를 찾았는데 해당 오브젝트가 사용 불가능한 상태라면
            //   ㄴ2번을 실행
            return null;
        }
    }
}
