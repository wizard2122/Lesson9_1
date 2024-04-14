using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private ICharacterFinder _characterFinder;
    private Func<Character, bool> _enemyChecker;

    private bool _isInit;

    public void Initialize(ICharacterFinder characterFinder, Func<Character, bool> enemyChecker)
    {
        _characterFinder = characterFinder;
        _enemyChecker = enemyChecker;
        _isInit = true;
    }

    private void Update()
    {
        if(_isInit == false)
            throw new InvalidOperationException(nameof(_isInit));

        IEnumerable<Character> characters = _characterFinder.Find();

        if (characters != null)
            Affect(characters.Where(character => _enemyChecker(character)));
    }

    protected abstract void Affect(IEnumerable<Character> characters);
}

class Base
{
    private int _c;

    public virtual void Compute(int a)
    {
        _c = a;
    }
}

class Child : Base
{
    public override void Compute(int a)
    {
       base.Compute(a);
    }
}
