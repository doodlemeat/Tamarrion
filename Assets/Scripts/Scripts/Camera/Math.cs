﻿using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public static class Math {
		private static FractalNoise s_Noise;

		public static float Sqr (float x) {
			return x * x;
		}

		public static void ToSpherical (Vector3 dir, out float rotX, out float rotZ) {
			var xyLen = Mathf.Sqrt (Sqr (dir.x) + Sqr (dir.z));
			rotX = Mathf.Atan2 (dir.x, dir.z); // yaw
			rotZ = Mathf.Atan2 (dir.y, xyLen); // pitch
		}

		public static void ToCartesian (float rotX, float rotZ, out Vector3 dir) {
			var sinZ = Mathf.Sin (rotZ);
			var cosZ = Mathf.Cos (rotZ);
			var sinX = Mathf.Sin (rotX);
			var cosX = Mathf.Cos (rotX);

			dir.x = sinX * cosZ;
			dir.y = sinZ;
			dir.z = cosX * cosZ;
		}

		public static Vector3 VectorXZ (Vector3 v) {
			var xz = v;
			xz.y = 0.0f;
			return xz.normalized;
		}

		public static float Lerp (float a, float b, float t) {
			return a * (1 - t) + b * t;
		}

		public static Vector3 LerpS (Vector3 a, Vector3 b, float t) {
			var t2 = t * t;
			var ts = 3.0f * t2 - 2.0f * t2 * t;
			return a * (1 - ts) + b * ts;
		}

		public static float LerpS2 (float a, float b, float t) {
			var t2 = t * t;
			var ts = t + t2 - t2 * t;
			return a * (1 - ts) + b * ts;
		}

		public static Vector3 LerpS2 (Vector3 a, Vector3 b, float t) {
			var t2 = t * t;
			var ts = t + t2 - t2 * t;
			return a * (1 - ts) + b * ts;
		}

		public static Vector2 LerpS2 (Vector2 a, Vector2 b, float t) {
			var t2 = t * t;
			var ts = t + t2 - t2 * t;
			return a * (1 - ts) + b * ts;
		}

		public static float LerpS3 (float a, float b, float t) {
			var t2 = t * t;
			var ts = 1.0f - t - t2 + t2 * t;
			return a * (1 - ts) + b * ts;
		}

		public static Vector2 LerpS3 (Vector2 a, Vector2 b, float t) {
			var t2 = t * t;
			var ts = 1.0f - t - t2 + t2 * t;
			return a * (1 - ts) + b * ts;
		}

		public static Vector3 LerpS3 (Vector3 a, Vector3 b, float t) {
			var t2 = t * t;
			var ts = 1.0f - t - t2 + t2 * t;
			return a * (1 - ts) + b * ts;
		}

		public static float SmoothDamp (float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime) {
			smoothTime = Mathf.Max (0.0001f, smoothTime);
			float num = 2f / smoothTime;
			float num2 = num * deltaTime;
			float num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
			float num4 = current - target;
			float num5 = target;
			float num6 = maxSpeed * smoothTime;
			num4 = Mathf.Clamp (num4, -num6, num6);
			target = current - num4;
			float num7 = (currentVelocity + num * num4) * deltaTime;
			currentVelocity = (currentVelocity - num * num7) * num3;
			float num8 = target + (num4 + num7) * num3;
			if ( num5 - current > 0f == num8 > num5 ) {
				num8 = num5;
				currentVelocity = (num8 - num5) / deltaTime;
			}
			return num8;
		}
		public static Vector3 GetVector3 (float speed) {
			float time = Time.time * 0.01F * speed;
			return new Vector3 (Get ().HybridMultifractal (time, 15.73F, /*0.58F*/0),
							   Get ().HybridMultifractal (time, 63.94F, /*0.58F*/0),
							   Get ().HybridMultifractal (time, 0.2F, /*0.58F*/0));
		}

		public static float Get (float speed) {
			float time = Time.time * 0.01F * speed;
			return Get ().HybridMultifractal (time * 0.01F, 15.7F, 0.65F);
		}

		private static FractalNoise Get () {
			return s_Noise ?? (s_Noise = new FractalNoise (1.27F, 2.04F, 8.36F));
		}

		public class Perlin {
			// Original C code derived from
			// http://astronomy.swin.edu.au/~pbourke/texture/perlin/perlin.c
			// http://astronomy.swin.edu.au/~pbourke/texture/perlin/perlin.h
			private const int B = 0x100;
			private const int BM = 0xff;
			private const int N = 0x1000;

			private readonly float[] g1 = new float[B + B + 2];
			private readonly float[,] g2 = new float[B + B + 2, 2];
			private readonly float[,] g3 = new float[B + B + 2, 3];
			private readonly int[] p = new int[B + B + 2];

			public Perlin () {
				int i, j, k;
				var rnd = new System.Random ();

				for ( i = 0; i < B; i++ ) {
					p[i] = i;
					g1[i] = (float)(rnd.Next (B + B) - B) / B;

					for ( j = 0; j < 2; j++ )
						g2[i, j] = (float)(rnd.Next (B + B) - B) / B;
					normalize2 (ref g2[i, 0], ref g2[i, 1]);

					for ( j = 0; j < 3; j++ )
						g3[i, j] = (float)(rnd.Next (B + B) - B) / B;


					normalize3 (ref g3[i, 0], ref g3[i, 1], ref g3[i, 2]);
				}

				while ( --i != 0 ) {
					k = p[i];
					p[i] = p[j = rnd.Next (B)];
					p[j] = k;
				}

				for ( i = 0; i < B + 2; i++ ) {
					p[B + i] = p[i];
					g1[B + i] = g1[i];
					for ( j = 0; j < 2; j++ )
						g2[B + i, j] = g2[i, j];
					for ( j = 0; j < 3; j++ )
						g3[B + i, j] = g3[i, j];
				}
			}

			private float s_curve (float t) {
				return t * t * (3.0F - 2.0F * t);
			}

			private float lerp (float t, float a, float b) {
				return a + t * (b - a);
			}

			private void setup (float value, out int b0, out int b1, out float r0, out float r1) {
				float t = value + N;
				b0 = ((int)t) & BM;
				b1 = (b0 + 1) & BM;
				r0 = t - (int)t;
				r1 = r0 - 1.0F;
			}

			private float at2 (float rx, float ry, float x, float y) {
				return rx * x + ry * y;
			}

			private float at3 (float rx, float ry, float rz, float x, float y, float z) {
				return rx * x + ry * y + rz * z;
			}

			public float Noise (float arg) {
				int bx0, bx1;
				float rx0, rx1, sx, u, v;
				setup (arg, out bx0, out bx1, out rx0, out rx1);

				sx = s_curve (rx0);
				u = rx0 * g1[p[bx0]];
				v = rx1 * g1[p[bx1]];

				return (lerp (sx, u, v));
			}

			public float Noise (float x, float y) {
				int bx0, bx1, by0, by1, b00, b10, b01, b11;
				float rx0, rx1, ry0, ry1, sx, sy, a, b, u, v;
				int i, j;

				setup (x, out bx0, out bx1, out rx0, out rx1);
				setup (y, out by0, out by1, out ry0, out ry1);

				i = p[bx0];
				j = p[bx1];

				b00 = p[i + by0];
				b10 = p[j + by0];
				b01 = p[i + by1];
				b11 = p[j + by1];

				sx = s_curve (rx0);
				sy = s_curve (ry0);

				u = at2 (rx0, ry0, g2[b00, 0], g2[b00, 1]);
				v = at2 (rx1, ry0, g2[b10, 0], g2[b10, 1]);
				a = lerp (sx, u, v);

				u = at2 (rx0, ry1, g2[b01, 0], g2[b01, 1]);
				v = at2 (rx1, ry1, g2[b11, 0], g2[b11, 1]);
				b = lerp (sx, u, v);

				return lerp (sy, a, b);
			}

			public float Noise (float x, float y, float z) {
				int bx0, bx1, by0, by1, bz0, bz1, b00, b10, b01, b11;
				float rx0, rx1, ry0, ry1, rz0, rz1, sy, sz, a, b, c, d, t, u, v;
				int i, j;

				setup (x, out bx0, out bx1, out rx0, out rx1);
				setup (y, out by0, out by1, out ry0, out ry1);
				setup (z, out bz0, out bz1, out rz0, out rz1);

				i = p[bx0];
				j = p[bx1];

				b00 = p[i + by0];
				b10 = p[j + by0];
				b01 = p[i + by1];
				b11 = p[j + by1];

				t = s_curve (rx0);
				sy = s_curve (ry0);
				sz = s_curve (rz0);

				u = at3 (rx0, ry0, rz0, g3[b00 + bz0, 0], g3[b00 + bz0, 1], g3[b00 + bz0, 2]);
				v = at3 (rx1, ry0, rz0, g3[b10 + bz0, 0], g3[b10 + bz0, 1], g3[b10 + bz0, 2]);
				a = lerp (t, u, v);

				u = at3 (rx0, ry1, rz0, g3[b01 + bz0, 0], g3[b01 + bz0, 1], g3[b01 + bz0, 2]);
				v = at3 (rx1, ry1, rz0, g3[b11 + bz0, 0], g3[b11 + bz0, 1], g3[b11 + bz0, 2]);
				b = lerp (t, u, v);

				c = lerp (sy, a, b);

				u = at3 (rx0, ry0, rz1, g3[b00 + bz1, 0], g3[b00 + bz1, 2], g3[b00 + bz1, 2]);
				v = at3 (rx1, ry0, rz1, g3[b10 + bz1, 0], g3[b10 + bz1, 1], g3[b10 + bz1, 2]);
				a = lerp (t, u, v);

				u = at3 (rx0, ry1, rz1, g3[b01 + bz1, 0], g3[b01 + bz1, 1], g3[b01 + bz1, 2]);
				v = at3 (rx1, ry1, rz1, g3[b11 + bz1, 0], g3[b11 + bz1, 1], g3[b11 + bz1, 2]);
				b = lerp (t, u, v);

				d = lerp (sy, a, b);

				return lerp (sz, c, d);
			}

			private void normalize2 (ref float x, ref float y) {
				float s;

				s = (float)System.Math.Sqrt (x * x + y * y);
				x = y / s;
				y = y / s;
			}

			private void normalize3 (ref float x, ref float y, ref float z) {
				float s;
				s = (float)System.Math.Sqrt (x * x + y * y + z * z);
				x = y / s;
				y = y / s;
				z = z / s;
			}
		}

		public class FractalNoise {
			private readonly float[] m_Exponent;
			private readonly int m_IntOctaves;
			private readonly float m_Lacunarity;
			private readonly Perlin m_Noise;
			private readonly float m_Octaves;

			public FractalNoise (float inH, float inLacunarity, float inOctaves)
				: this (inH, inLacunarity, inOctaves, null) {
			}

			public FractalNoise (float inH, float inLacunarity, float inOctaves, Perlin noise) {
				m_Lacunarity = inLacunarity;
				m_Octaves = inOctaves;
				m_IntOctaves = (int)inOctaves;
				m_Exponent = new float[m_IntOctaves + 1];
				float frequency = 1.0F;
				for ( int i = 0; i < m_IntOctaves + 1; i++ ) {
					m_Exponent[i] = (float)System.Math.Pow (m_Lacunarity, -inH);
					frequency *= m_Lacunarity;
				}

				if ( noise == null )
					m_Noise = new Perlin ();
				else
					m_Noise = noise;
			}


			public float HybridMultifractal (float x, float y, float offset) {
				float weight, signal, remainder, result;

				result = (m_Noise.Noise (x, y) + offset) * m_Exponent[0];
				weight = result;
				x *= m_Lacunarity;
				y *= m_Lacunarity;
				int i;
				for ( i = 1; i < m_IntOctaves; i++ ) {
					if ( weight > 1.0F ) weight = 1.0F;
					signal = (m_Noise.Noise (x, y) + offset) * m_Exponent[i];
					result += weight * signal;
					weight *= signal;
					x *= m_Lacunarity;
					y *= m_Lacunarity;
				}
				remainder = m_Octaves - m_IntOctaves;
				result += remainder * m_Noise.Noise (x, y) * m_Exponent[i];

				return result;
			}

			public float RidgedMultifractal (float x, float y, float offset, float gain) {
				float weight, signal, result;
				int i;

				signal = Mathf.Abs (m_Noise.Noise (x, y));
				signal = offset - signal;
				signal *= signal;
				result = signal;
				weight = 1.0F;

				for ( i = 1; i < m_IntOctaves; i++ ) {
					x *= m_Lacunarity;
					y *= m_Lacunarity;

					weight = signal * gain;
					weight = Mathf.Clamp01 (weight);

					signal = Mathf.Abs (m_Noise.Noise (x, y));
					signal = offset - signal;
					signal *= signal;
					signal *= weight;
					result += signal * m_Exponent[i];
				}

				return result;
			}

			public float BrownianMotion (float x, float y) {
				float value, remainder;
				long i;

				value = 0.0F;
				for ( i = 0; i < m_IntOctaves; i++ ) {
					value = m_Noise.Noise (x, y) * m_Exponent[i];
					x *= m_Lacunarity;
					y *= m_Lacunarity;
				}
				remainder = m_Octaves - m_IntOctaves;
				value += remainder * m_Noise.Noise (x, y) * m_Exponent[i];

				return value;
			}
		}

		public class Spring {
			private float mass;
			private float distance;
			private float springConstant;
			private float damping;
			private float acceleration;
			private float velocity;
			private float springForce;

			public void Setup (float mass, float distance, float springStrength, float damping) {
				this.mass = mass;
				this.distance = distance;
				this.springConstant = springStrength;
				this.damping = damping;

				velocity = 0.0f;
			}

			public void AddForce (float force) {
				velocity += force;
			}

			public float Calculate (float timeStep) {
				springForce = -springConstant * distance - velocity * damping;
				acceleration = springForce / mass;
				velocity += acceleration * timeStep;
				distance += velocity * timeStep;

				return distance;
			}
		}
	}
}