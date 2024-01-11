using System.IO;
using TMPro;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace HuggingFace.API.Demos
{
    public class controlador_treasure : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI statusText;
        public GameObject treasure; // Referencia al tesoro
        private bool FlagTreasure = false;
        private bool FlagWin = false;

        private AudioClip voiceClip;
        private byte[] audioData;
        private bool isRecording;

        public delegate void CollisionHandler();
        public delegate void SendHint(string hint, int id);
        public static event CollisionHandler AddOnePoint;
        public static event SendHint history_treasure;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z) && FlagTreasure || Input.GetButtonDown("Fire1") && FlagTreasure)
            { // Click izquierdo para comenzar a grabar
                BeginAudioCapture();
            }

            if ((isRecording && !FlagTreasure) || Input.GetKeyDown(KeyCode.X) && isRecording || Input.GetButtonDown("Fire2") && isRecording)
            { // Click derecho para detener
                EndAudioCapture();
            }
        }

        private void BeginAudioCapture()
        {
            statusText.color = Color.green;
            statusText.text = "Grabando...";
            voiceClip = Microphone.Start(null, false, 10, 44100);
            isRecording = true;
        }

        private void EndAudioCapture()
        {
            try
            {
                int sampleCount = Microphone.GetPosition(null);
                Microphone.End(null);
                float[] sampleArray = new float[sampleCount * voiceClip.channels];
                voiceClip.GetData(sampleArray, 0);
                audioData = ConvertToWAV(sampleArray, voiceClip.frequency, voiceClip.channels);
                isRecording = false;
                TransmitAudioData();
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error al detener la grabación: {ex.Message}");
            }
        }

        private void TransmitAudioData()
        {
            statusText.color = Color.blue;
            statusText.text = "Enviando audio...";
            HuggingFaceAPI.AutomaticSpeechRecognition(audioData, response =>
            {
                statusText.color = Color.white;
                statusText.text = response;
                InterpretVoiceCommand(response);
            }, error =>
            {
                statusText.color = Color.red;
                statusText.text = error;
            });
        }

        private void InterpretVoiceCommand(string voiceOutput)
        {
            statusText.text = voiceOutput;

            if (voiceOutput.ToLower().Contains("banana") && treasure.tag == "treasure good")
            {
                statusText.text = "¡Enhorabuena, valiente explorador! Al abrir el cofre, descubres que el verdadero tesoro no es material. En su interior, encuentras algo mucho más valioso: el conocimiento, la sabiduría y la experiencia ganada a lo largo de tu viaje. Estos son regalos que te acompañarán siempre, mucho después de que el juego haya terminado. ¡Felicidades por tu logro y el viaje que has completado!";
                AddOnePoint();
                history_treasure("", 3);
            }
            // else if (voiceOutput.ToLower().Contains("love") && treasure.tag == "treasure bad")
            // {
            //     statusText.text = "¡Has perdido!";
            // }
        }

        private void MovetreasureBackward()
        {
            treasure.transform.Translate(-Vector3.forward * 5.0f);
        }

        private void MaketreasureJump()
        {
            Rigidbody rb = treasure.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * 5.0f, ForceMode.Impulse);
            }
            else
            {
                Debug.LogWarning("Rigidbody no encontrado en la tesoro");
            }
        }

        private byte[] ConvertToWAV(float[] samples, int sampleRate, int channelCount)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(memoryStream))
                {
                    WriteWavHeader(writer, sampleRate, channelCount, samples.Length);
                    foreach (var sample in samples)
                    {
                        writer.Write((short)(sample * short.MaxValue));
                    }
                }
                return memoryStream.ToArray();
            }
        }

        private void WriteWavHeader(BinaryWriter writer, int sampleRate, int channelCount, int sampleCount)
        {
            writer.Write("RIFF".ToCharArray());
            writer.Write(36 + sampleCount * 2);
            writer.Write("WAVE".ToCharArray());
            writer.Write("fmt ".ToCharArray());
            writer.Write(16);
            writer.Write((ushort)1);
            writer.Write((ushort)channelCount);
            writer.Write(sampleRate);
            writer.Write(sampleRate * channelCount * 2);
            writer.Write((ushort)(channelCount * 2));
            writer.Write((ushort)16);
            writer.Write("data".ToCharArray());
            writer.Write(sampleCount * 2);
        }

        public void OnPointerEnter()
        {
            FlagTreasure = true;
            Debug.Log("Has mirado al tesoro");
        }

        public void OnPointerExit()
        {
            FlagTreasure = false;
        }
    }
}