﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPositionWorldCoordinate;
    private Vector3 startPositionBoardCoordinate;
    public static GameObject itemBeingDragged;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Begin");
        startPositionBoardCoordinate = TileSelector.coordinateToIndex;
        startPositionWorldCoordinate = this.transform.position;
        transform.SetSiblingIndex(transform.parent.childCount-1);
        //Debug.Log(startPosition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag");
        GetComponent<RectTransform>().position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag End");
        RectTransform trans = GetComponent<RectTransform>();

        if (TileSelector.dropTargetType == DropTarget.Board) // Droping on board
        {
            // Starting drag from the board and droping on the board
            if (startPositionBoardCoordinate.x > -trans.rect.size.x / 2 && startPositionBoardCoordinate.x < trans.rect.size.x / 2 && startPositionBoardCoordinate.y > -trans.rect.size.y / 2 && startPositionBoardCoordinate.y < trans.rect.size.y / 2)
            {
                // if the drop position is empty(true) then drop otherwise drop at start position
                if (GameManager.globalGameBoard.getBoard((int)(TileSelector.coordinateToIndex.x / 31.7f) + 7, (int)(TileSelector.coordinateToIndex.y / 31.7f) + 7))
                {
                    GetComponent<RectTransform>().position = TileSelector.dropGoPos;
                    transform.SetParent(TileSelector.dropTarget.transform, true);
                    GameManager.globalGameBoard.setBoard((int)(TileSelector.coordinateToIndex.x / 31.7f) + 7, (int)(TileSelector.coordinateToIndex.y / 31.7f) + 7, false);
                    GameManager.globalGameBoard.setBoard((int)(startPositionBoardCoordinate.x / 31.7f) + 7, (int)(startPositionBoardCoordinate.y / 31.7f) + 7, true);
                }
                else
                    GetComponent<RectTransform>().position = startPositionWorldCoordinate;
            }
            else // Starting drag from the rack of tiles and dropping on the board
            {
                // if the drop position is empty(true) then drop otherwise drop in the rack of tiles 
                if (GameManager.globalGameBoard.getBoard((int)(TileSelector.coordinateToIndex.x / 31.7f) + 7, (int)(TileSelector.coordinateToIndex.y / 31.7f) + 7))
                {
                    GetComponent<RectTransform>().position = TileSelector.dropGoPos;
                    transform.SetParent(TileSelector.dropTarget.transform, true);
                    GameManager.globalGameBoard.setBoard((int)(TileSelector.coordinateToIndex.x / 31.7f) + 7, (int)(TileSelector.coordinateToIndex.y / 31.7f) + 7, false);
                }
                else
                    GetComponent<RectTransform>().position = startPositionWorldCoordinate;
            }
        }
        else if(TileSelector.dropTargetType == DropTarget.Rack) // Droping on rack of tiles
        {
            GetComponent<RectTransform>().position = TileSelector.dropGoPos;
            transform.SetParent(TileSelector.dropTarget.transform, true);
        }
        else if(TileSelector.dropTargetType == DropTarget.Exchange) // Droping on exchange rack
        {

        }
        else // Droping on empty space
            GetComponent<RectTransform>().position = startPositionWorldCoordinate;
    }
}
