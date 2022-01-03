﻿using UnityEngine;

namespace GleyTrafficSystem
{
    public interface ISetupWindow
    {
        string GetWindowTitle();
        ISetupWindow Initialize(WindowProperties windowProperties);
        /// <summary>
        /// Draw the window buttons
        /// </summary>
        /// <param name="width">with of the window</param>
        /// <param name="height">height of the window</param>
        /// <returns>false if closed</returns>
        bool DrawInWIndow(float width, float height);
        void DrawInScene();
        void MouseMove(Vector3 mousePosition);
        void LeftClick(Vector3 mousePosition);   
        void RightClick(Vector3 mousePosition);
        void UndoAction();
        WindowType GetWindowType();
        void DestroyWindow();
    }
}