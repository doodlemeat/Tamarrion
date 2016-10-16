using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public enum FSSkillType {
		FS_Type_Base,
		FS_Type_Area,
		FS_Type_Projectile,
	}

	public enum FSSkillElement {
		FS_Elem_Holy,
		FS_Elem_Magic,
		FS_Elem_Nature,
		FS_Elem_Defense,
		FS_Elem_War,
		FS_Elem_Count,
	}

	public enum FSSkillShape {
		FS_Shape_Box,
		FS_Shape_Circle,
		FS_Shape_Cone,
	}

	public enum FSSkillPlacing {
		FS_Placing_FromPlayer,
		FS_Placing_PlayerIsCenter,
		FS_Placing_FreePlace,
	}

	public enum FSSkillStates {
		FS_State_Inactive,
		FS_State_Casting,
		FS_State_Perform,
		FS_State_Channeling,
		FS_State_Recover,
	}

	public abstract class FSSkillBase : MonoBehaviour {
		public string skillName;
		public Texture2D skillIcon;
		public float cooldown = 2;
		public float duration = 0;
		public float range = 10;
		public float shapeSize = 2;
		public bool showRange = false;
		public bool noPlacement = false;
		public FSSkillType type = FSSkillType.FS_Type_Base;
		public FSSkillElement element = FSSkillElement.FS_Elem_Holy;
		public SkillElement Element;
		public FSSkillShape shape = FSSkillShape.FS_Shape_Box;
		public FSSkillPlacing placing = FSSkillPlacing.FS_Placing_FromPlayer;
		public Texture2D shapeTexture;
		public Texture2D chargeTexture;
		public Collider shapeCollider;
		public float MagicDamagePercentage = 1f;
		public float PhysicalDamagePercentage = 1f;
		public TopgunTimer cooldownTimer = new TopgunTimer ();
		FSSkillStates m_currentState = FSSkillStates.FS_State_Inactive;

		[Header ("God Power Tribute Gain")]
		public int TributeGainHoly = 0;
		public int TributeGainMagic = 0;
		public int TributeGainNature = 0;
		public int TributeGainDefense = 0;
		public int TributeGainWar = 0;

		[Tooltip ("Clear all God Power Points for own God Power on use")]
		public bool removeAllGPPOnUse = false;

		[Tooltip ("Clear amount of God Power Points for own God Power on use")]
		public int removeAmountGPPOnUse = 0;

		//STATE: CASTING
		[Header ("State: Casting")]
		public string CastAnimationName = "Cast";
		public string CastLoopAnimationName = "Looping spell";
		public float CastTime = 0;
		public bool CastCancelOnMove = true;
		public bool CastCanMove = true;
		public bool CastCanRotate = true;
		public float CastMovespeedMod = 0.5f;

		//STATE: PERFORM
		[Header ("State: Perform")]
		public string PerformAnimationName = "";
		public float PerformTime = 0;
		public bool PerformCanMove = true;
		public bool PerformCanRotate = true;
		public float PerformMovespeedMod = 0.5f;

		//STATE: RECOVER
		[Header ("State: Recover")]
		public string RecoverAnimationName = "";
		public float RecoverTime = 0;
		public bool RecoverCanMove = true;
		public bool RecoverCanRotate = true;
		public float RecoverMovespeedMod = 0.5f;

		//STATE: CHANNELING
		[Header ("State: Channeling")]
		public string ChannelingAnimationName = "";
		public bool isChanneling = false;
		public bool CanBeCanceled = false;
		public float ChannelingTime = 0;
		public bool ChannelingCanMove = true;
		public bool ChannelingCanRotate = true;
		public float ChannelingMovespeedMod = 0.5f;

		[Header ("Finish Casting")]
		public string FinishAnimationName = "";

		public void CancelSkill () {
			ResetStateToInactive ();
		}

		public FSSkillStates GetCurrentState () {
			return m_currentState;
		}

		public void AdvanceState () {
			if ( m_currentState == FSSkillStates.FS_State_Inactive )
				m_currentState = FSSkillStates.FS_State_Casting;
			else if ( m_currentState == FSSkillStates.FS_State_Casting )
				m_currentState = FSSkillStates.FS_State_Perform;
			else if ( m_currentState == FSSkillStates.FS_State_Perform )
				m_currentState = FSSkillStates.FS_State_Recover;
			else if ( m_currentState == FSSkillStates.FS_State_Recover )
				m_currentState = FSSkillStates.FS_State_Inactive;
		}

		public int GetTributeGainByElement (FSSkillElement p_element) {
			if ( p_element == FSSkillElement.FS_Elem_Holy )
				return TributeGainHoly;
			else if ( p_element == FSSkillElement.FS_Elem_Magic )
				return TributeGainMagic;
			else if ( p_element == FSSkillElement.FS_Elem_Nature )
				return TributeGainNature;
			else if ( p_element == FSSkillElement.FS_Elem_Defense )
				return TributeGainDefense;
			else if ( p_element == FSSkillElement.FS_Elem_War )
				return TributeGainWar;

			return 0;
		}

		public void SetState (FSSkillStates p_state) {
			m_currentState = p_state;
		}

		public void ResetStateToInactive () {
			m_currentState = FSSkillStates.FS_State_Inactive;
		}

		public bool HasCastAnimationName () {
			return CastAnimationName != "";
		}

		public bool HasCastLoopAnimationName () {
			return CastLoopAnimationName != "";
		}

		public bool HasPerformAnimationName () {
			return PerformAnimationName != "";
		}

		public bool HasRecoverAnimationName () {
			return RecoverAnimationName != "";
		}

		public bool HasChannelingAnimationName () {
			return ChannelingAnimationName != "";
		}

		public bool HasFinishAnimationName () {
			return FinishAnimationName != "";
		}

		public virtual void PerformStart () { }
		public virtual void PerformUpdate () { }
		public virtual void PerformEnd () { }

		public virtual void RecoverStart () { }
		public virtual void RecoverUpdate () { }
		public virtual void RecoverEnd () { }

		public virtual void ChannelStart () { }
		public virtual void ChannelUpdate () { }
		public virtual void ChannelEnd () { }

		abstract public void ApplySkillEffect ();

		abstract public void SkillEnd ();
	}
}