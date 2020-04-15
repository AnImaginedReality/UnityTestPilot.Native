using System.Linq;
using AIR.UnityTestPilot.Interactions;
using UnityEngine;

namespace AIR.UnityTestPilot.Queries {
    public class NamedElementQueryNative : NamedElementQuery
    {
        public NamedElementQueryNative(string name) : base(name){ }

        public override UiElement[] Search() {

            var elements = GameObject
                .FindObjectsOfType<GameObject>();

            if (elements.Any()) {
                var namedElements = elements
                    .Where(o => o.name == _queryName)
                    .ToArray();
                if(namedElements.Any())
                    return namedElements.Select(o => 
                        new UiElementNative(o)).ToArray();
            }
            
            return null;
        }
    }
}