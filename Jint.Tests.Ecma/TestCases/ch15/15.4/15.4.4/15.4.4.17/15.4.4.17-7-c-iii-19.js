/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.17/15.4.4.17-7-c-iii-19.js
 * @description Array.prototype.some - return value of callbackfn is a Number object
 */


function testcase() {

        function callbackfn(val, idx, obj) {
            return new Number();
        }

        return [11].some(callbackfn);
    }
runTestCase(testcase);
