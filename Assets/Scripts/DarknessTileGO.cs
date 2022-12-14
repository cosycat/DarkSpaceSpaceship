using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DarknessTileGO : TileGO {
    private SpriteRenderer _spriteRenderer;

    private float _animationDelay = 0;
    private float _animationStartTime;
    private float _animationStartValue;
    private float _animationGoalValue;
    private float _animationDuration;
    private bool _isAnimating;
    
    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (!_isAnimating) return;
        if (_animationDelay > 0) {
            _animationDelay -= Time.deltaTime;
            return;
        }

        var newAlpha = Mathf.Lerp(_animationStartValue, _animationGoalValue, (Time.timeSinceLevelLoad - _animationStartTime) / _animationDuration);
        // Debug.Log($"new alpha: {newAlpha}");
        if (newAlpha >= _animationGoalValue) { // reached our animation goal!
            _isAnimating = false;
            newAlpha = _animationGoalValue;
            // set player back to bright, in case they walked around after a flash
            RoomManager.Instance.GetDarknessTileGOAt(Player.Instance.GoalPosition.x, Player.Instance.GoalPosition.y).Brighten(0);
        }

        var color = _spriteRenderer.color;
        color = new Color(color.r, color.g, color.b, newAlpha);
        _spriteRenderer.color = color;
    }

    public void Brighten(float timeUntilBright, float delay = 0, bool overrideCurrentTransition = false) {
        ChangeAlphaTo(0, timeUntilBright, delay, overrideCurrentTransition);
    }

    public void Darken(float timeUntilBright, float delay = 0, bool overrideCurrentTransition = false) {
        ChangeAlphaTo(1, timeUntilBright, delay, overrideCurrentTransition);
    }

    private void ChangeAlphaTo(float goalAlpha, float timeUntilBright, float delay = 0, bool overrideCurrentTransition = false) {
        if (_isAnimating && !overrideCurrentTransition) {
            return;
        }
        if (timeUntilBright <= 0 && delay <= 0) {
            SetAlphaImmediately(goalAlpha);
            return;
        }
        _animationDelay = delay;
        _animationStartTime = Time.timeSinceLevelLoad + delay;
        _animationDuration = timeUntilBright;
        _animationStartValue = _spriteRenderer.color.a;
        _animationGoalValue = goalAlpha;
        _isAnimating = true;
    }

    private void SetAlphaImmediately(float alpha) {
        _isAnimating = false;
        var color = _spriteRenderer.color;
        color = new Color(color.r, color.g, color.b, alpha);
        _spriteRenderer.color = color;
    }
}