using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ThirdPersonShooterControl : MonoBehaviour
{
   [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
   [SerializeField] private float normalSensitivity;
   [SerializeField] private float aimSensitivity;
   [SerializeField] private Transform debugTransform;
   [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
   [SerializeField] private Transform pfBulletProjectile;
   [SerializeField] private Transform spawnBulletPosition;
   [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    
    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;

    private void Awake(){
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
    }
    private void Update(){
        Vector3 mouceWorldPosition = Vector3.zero;
        
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint); 
        Transform hitTransform = null;
        if(Physics.Raycast(ray, out RaycastHit raycastHit,999f,aimColliderLayerMask)){
            debugTransform.position = raycastHit.point;
            mouceWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }

        if(starterAssetsInputs.aim){
                aimVirtualCamera.gameObject.SetActive(true);
                thirdPersonController.SetSensitivity(aimSensitivity);
                thirdPersonController.SetRotateOnMove(false);
                animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

                Vector3 worldAimTarget = mouceWorldPosition;
                worldAimTarget.y = transform.position.y;
                Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

                
                transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
            } else {
                aimVirtualCamera.gameObject.SetActive(false);
                thirdPersonController.SetSensitivity(normalSensitivity);
                thirdPersonController.SetRotateOnMove(true);
                animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }
        if (starterAssetsInputs.shoot) {

            Vector3 aimDir = (mouceWorldPosition - spawnBulletPosition.position).normalized;
            Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            starterAssetsInputs.shoot = false;
        }
    }
}
