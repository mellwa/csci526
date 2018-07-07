using UnityEngine;
using System.Collections;

public class TestAnimation : MonoBehaviour
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
		}
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Keypad9) == true) StartCoroutine("cheatAniPlay", no);
		if (Input.GetKeyDown(KeyCode.Keypad8) == true) gameObject.GetComponent<SmoothMoves.BoneAnimation>().Stop();
		if (Input.GetKeyDown(KeyCode.Keypad7) == true) gameObject.GetComponent<SmoothMoves.BoneAnimation>().CrossFade("Atk_" + no);
		if (Input.GetKeyDown(KeyCode.Keypad6) == true) gameObject.GetComponent<SmoothMoves.BoneAnimation>().CrossFade("Idle_" + no);
		if (Input.GetKeyDown (KeyCode.Keypad1) == true) ChangeNo (0);
		if (Input.GetKeyDown (KeyCode.Keypad2) == true) ChangeNo (1);
		if (Input.GetKeyDown (KeyCode.Keypad3) == true) ChangeNo (2);
		if (Input.GetKeyDown (KeyCode.Keypad4) == true) ChangeNo (3);
		if (Input.GetKeyDown (KeyCode.Keypad5) == true) ChangeNo (4);
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
	void ChangeNo(int plus)
	{
		SmoothMoves.BoneAnimation boneAni = gameObject.GetComponent<SmoothMoves.BoneAnimation> ();
		string aniName = gameObject.name;
		print (aniName);
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
				StopCoroutine ("cheatAniPlay");
				StartCoroutine ("cheatAniPlay", no);
			}
		}
	}
}
