using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Core.ItemSystem;

[CustomEditor(typeof(LootBoxDataBundle))]
public class ChestLootDataBundleEditor : Editor
{
    private Color _defaultGUIColor;

    private void OnEnable()
    {
        _defaultGUIColor = GUI.backgroundColor;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.LabelField("CHEST VARIABLES", EditorStyles.boldLabel);
        var baseCost = serializedObject.FindProperty("_baseCost");
        baseCost.floatValue = EditorGUILayout.FloatField("Base cost", baseCost.floatValue);
        var costPerOpen = serializedObject.FindProperty("_costPerOpen");
        costPerOpen.floatValue = EditorGUILayout.FloatField("Cost per open", costPerOpen.floatValue);


        EditorGUILayout.EndVertical();
        EditorGUILayout.Space(20f);

        var array = serializedObject.FindProperty("_data");
        float totalRate = 0;

        if (array.arraySize > 0)
        {
            for (int i = 0; i < array.arraySize; i++)
            {
                var elementAtIndex = array.GetArrayElementAtIndex(i);
                totalRate += elementAtIndex.FindPropertyRelative("_lootRate").floatValue;
            }
        }

        if(totalRate > 1)
        {
            GUI.backgroundColor = Color.red;
        }
        else
        {
            GUI.backgroundColor = _defaultGUIColor;
        }

        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.LabelField("CHEST LOOT LIST", EditorStyles.boldLabel);


        if (array.arraySize > 0)
        {
            for (int i = 0; i < array.arraySize; i++)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);

                var elementAtIndex = array.GetArrayElementAtIndex(i);


                DrawName(elementAtIndex);
                DrawID(elementAtIndex);
                DrawRewardRate(elementAtIndex);
                DrawSprite(elementAtIndex);
                DrawLootRate(elementAtIndex);
                DrawMaxLevel(elementAtIndex);

                if (GUILayout.Button("Remove"))
                {
                    array.DeleteArrayElementAtIndex(i);
                    break;
                }

                EditorGUILayout.EndVertical();
                EditorGUILayout.Space();
            }
        }
        else
        {
            EditorGUILayout.LabelField("There is no element");
        }

        if (GUILayout.Button("Add"))
        {
            array.InsertArrayElementAtIndex(array.arraySize);
        }

        EditorGUILayout.EndVertical();

        

        serializedObject.ApplyModifiedProperties();
    }

    private static void DrawID(SerializedProperty elementAtIndex)
    {
        var id = elementAtIndex.FindPropertyRelative("_id");
        id.intValue = EditorGUILayout.IntField("Saveable ID", id.intValue);
    }

    private static void DrawSprite(SerializedProperty elementAtIndex)
    {
        var sprite = elementAtIndex.FindPropertyRelative("_sprite");
        sprite.objectReferenceValue = (Sprite)EditorGUILayout.ObjectField("Icon",
            sprite.objectReferenceValue, typeof(Sprite), false);
    }


    private static void DrawName(SerializedProperty elementAtIndex)
    {
        var name = elementAtIndex.FindPropertyRelative("_name");
        name.stringValue = EditorGUILayout.TextField("Name", name.stringValue);
    }

    private static void DrawRewardRate(SerializedProperty elementAtIndex)
    {
        var rewardRate = elementAtIndex.FindPropertyRelative("_rewardRate");
        rewardRate.floatValue = EditorGUILayout.FloatField("Reward rate", rewardRate.floatValue);
    }

    private static void DrawLootRate(SerializedProperty elementAtIndex)
    {
        var lootRate = elementAtIndex.FindPropertyRelative("_lootRate");

        lootRate.floatValue = EditorGUILayout.Slider("Loot rate", lootRate.floatValue, 0f, 1f);
        /*        var rarity = elementAtIndex.FindPropertyRelative("_rarity");
                rarity.intValue = (int)(Rarity)EditorGUILayout.EnumPopup("Rarity", (Rarity)rarity.intValue);*/

    }

    private static void DrawMaxLevel(SerializedProperty elementAtIndex)
    {
        var maxLevel = elementAtIndex.FindPropertyRelative("_maxLevel");

        maxLevel.intValue = EditorGUILayout.IntField("Max level", maxLevel.intValue);
        /*        var rarity = elementAtIndex.FindPropertyRelative("_rarity");
                rarity.intValue = (int)(Rarity)EditorGUILayout.EnumPopup("Rarity", (Rarity)rarity.intValue);*/

    }
}
