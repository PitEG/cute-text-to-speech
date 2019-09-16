using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PitGan {

	public enum Alphabet {
		A, B, C, D, E, F, G, H, I, J, K, L, M,
		N, O, P, Q, R, S, T, U, V, W, X, Y, Z
	}

	[RequireComponent(typeof(AudioSource))]
	public class CuteTextToSpeech : MonoBehaviour {

		public AudioClip[] alphabet;
		public float gapBetweenLetters;
		private AudioSource audioSource;

		private void Awake() {
			audioSource = GetComponent<AudioSource>();
		}

		public void SayLetter(Alphabet letter) {
			audioSource.Stop();
			audioSource.PlayOneShot(alphabet[(int)letter]);
		}

		public void Say(string text) {
			StartCoroutine(SayCoroutine(text));
		}

		public IEnumerator SayCoroutine(string text) {
			//don't say anything if the text passed in is null
			if (text == null) {
				yield return null;
			}
			for (int i = 0; i < text.Length; i++) {
				SayCharAtIndex(text, i);
				yield return new WaitForSeconds(gapBetweenLetters);
			}
			audioSource.Stop();
		}

		public void SayCharAtIndex(string text, int index) {
			char currentChar = text[index];
			switch (currentChar) {
				case 'a':
					SayLetter(Alphabet.A); break;
				case 'b':
					SayLetter(Alphabet.B); break;
				case 'c':
					SayLetter(Alphabet.C); break;
				default:
					break;
			}
		}

	}
}
