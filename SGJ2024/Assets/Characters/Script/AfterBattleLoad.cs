using Unity.VisualScripting;
using UnityEngine;

namespace BattleSystem {
    public class AfterBattleLoad : MonoBehaviour
    {
        public bool IsDeath { get; set; }
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private int _currentBattleSceneNumber;
        //[SerializeField] private int _nextBattleSceneNumber;
        [SerializeField] private string _guildSceneName = "Guild";
        [SerializeField] private string _dialogSceneName = "Dialog";
        [SerializeField] private string _deathSceneName = "Guild";
        [SerializeField] private string _nextSceneName = "Dialog0_1";
        [SerializeField] private bool _isNotEducation = true;

        public void Start()
        {
            if (_isNotEducation && !IsDeath)
            {
                PlayerData loadedData = SaveManager.LoadPlayerData();
                if (loadedData.lv > _currentBattleSceneNumber)
                {
                    _sceneLoader.scene_name = _guildSceneName;

                }
                else
                {
                    _sceneLoader.scene_name = $"{_dialogSceneName}{_currentBattleSceneNumber}";
                }
            }
            else
            {
                if (IsDeath) 
                {
                    _sceneLoader.scene_name = _deathSceneName;
                }
                else
                {
                    _sceneLoader.scene_name = _nextSceneName;

                }
            }
            _sceneLoader.gameObject.SetActive(true);
        }

    }
}