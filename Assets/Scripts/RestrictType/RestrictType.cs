using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RestrictType : PropertyAttribute
{
    public Type objectType;
    public RestrictType(Type searchObjectType) {
        this.objectType = searchObjectType;
    }
}
