using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFireTowerAnim : MonoBehaviour {

	private string _no;
	public string no;
	public int changeTo;
	public Transform SpriteTrans;

	void Start()
	{
		if (string.IsNullOrEmpty (no) == true)
		{
			SmoothMoves.BoneAnimation boneAni = gameObject.GetComponent<SmoothMoves.BoneAnimation>();
			string aniName = boneAni.GetAnimationClipName (0);
			no = _no = aniName.Split ('_') [1];
			ChangeNo (changeTo);
			StartCoroutine("cheatAniPlay", no);

		}
	}
	void Update()
	{
		if(Time.timeScale == 1)
		SpriteTrans.gameObject.GetComponent<Renderer>().enabled =false;


	}
	IEnumerator cheatAniPlay(string no)
	{
		SmoothMoves.BoneAnimation boneAni = gameObject.GetComponent<SmoothMoves.BoneAnimation>();

		string ani = "Atk_" + no;
		int i = boneAni.GetAnimationClipIndex(ani);
		
		if (i == -1) yield break;
		
		if (boneAni.IsPlaying(ani) == true) boneAni.Stop();
		

		
		boneAni.CrossFade(ani);
		
		yield return new WaitForSeconds(boneAni[ani].length);
		
		if (boneAni != null)
			boneAni.CrossFade("Idle_" + no);
	}
	void ChangeNo(int plus)
	{
		SmoothMoves.BoneAnimation boneAni = gameObject.GetComponent<SmoothMoves.BoneAnimation> ();
		string aniName = gameObject.name;
		//print (aniName);
		string[] arr = aniName.Split ('_');
		if (arr.Length >= 3) {
			int n2;
			int.TryParse (arr[2], out n2);
			int n1;
			int.TryParse (arr[1], out n1);
			if (n2 - n1 >= plus) {
				int n;
				int.TryParse (_no, out n);
				no = (n + plus).ToString ().PadLeft (4, '0');
				boneAni.Stop ();
				//StopCoroutine ("cheatAniPlay");
				//StartCoroutine ("cheatAniPlay", no);
			}
		}
	}
}
