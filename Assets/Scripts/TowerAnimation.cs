using UnityEngine;
using System.Collections;

public class TowerAnimation : MonoBehaviour
{
	private string _no;
	public string no;

	void Start()
	{
		if (string.IsNullOrEmpty (no) == true)
		{
			SmoothMoves.BoneAnimation boneAni = gameObject.GetComponent<SmoothMoves.BoneAnimation>();
			string aniName = boneAni.GetAnimationClipName (0);
			no = _no = aniName.Split ('_') [1];

			StartCoroutine("cheatAniPlay",  no);
		}
	}
	void Update()
	{
		//if (Input.GetKeyDown(KeyCode.Keypad9) == true) StartCoroutine("cheatAniPlay", no);
	// 	if (Input.GetKeyDown(KeyCode.Keypad8) == true) gameObject.GetComponent<SmoothMoves.BoneAnimation>().Stop();
	// 	if (Input.GetKeyDown(KeyCode.Keypad7) == true) gameObject.GetComponent<SmoothMoves.BoneAnimation>().CrossFade("Atk_" + no);
	// 	if (Input.GetKeyDown(KeyCode.Keypad6) == true) gameObject.GetComponent<SmoothMoves.BoneAnimation>().CrossFade("Idle_" + no);

	 }
	IEnumerator cheatAniPlay(string no)
	{
		SmoothMoves.BoneAnimation boneAni = gameObject.GetComponent<SmoothMoves.BoneAnimation>();

		string ani = "Atk_" + no;
		int i = boneAni.GetAnimationClipIndex(ani);
		
		if (i == -1) yield break;
		
		if (boneAni.IsPlaying(ani) == true) boneAni.Stop();
		
		Debug.Log(boneAni[ani].length);
		
		boneAni.CrossFade(ani);
		
		yield return new WaitForSeconds(boneAni[ani].length);
		
		if (boneAni != null)
			boneAni.CrossFade("Idle_" + no);
	}

}
