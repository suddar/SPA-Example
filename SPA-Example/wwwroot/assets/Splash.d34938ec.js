import{S as I,i as X,s as j,e as L,X as u,a as P,b as t,r as v,Y as G,c as b,d as o,p as S,I as A,q as Z,J as F,f as y,K as O,Z as C}from"./index.e9e1813c.js";import{d as q}from"./index.c2f4aa2d.js";function U(g){let e,l,s,d,f,p,n,a;return{c(){e=u("path"),s=u("linearGradient"),d=u("stop"),f=u("stop"),p=u("path"),t(e,"d",` M 564.251 625.251 L 659 720 L 700 675 L 781 994 L 457 921 L 506\r
            873 L 249 626 L 249 626 L 542.5 626 C 549.812 626 557.065 625.748\r
            564.251 625.251 Z `),t(e,"fill","url(#_lgradient_2)"),t(e,"class","svelte-1mewqmc"),t(d,"offset","2.1739130434782608%"),t(d,"stop-opacity","1"),v(d,"stop-color","rgb(241,93,232)"),t(f,"offset","100%"),t(f,"stop-opacity","1"),v(f,"stop-color","rgb(184,58,177)"),t(s,"id","_lgradient_3"),t(s,"x1","0.13056277056277052"),t(s,"y1","0.05232744783306609"),t(s,"x2","0.9350649350649348"),t(s,"y2","0.7710005350454795"),t(s,"gradientTransform","matrix(770,0,0,623,84,3)"),t(s,"gradientUnits","userSpaceOnUse"),t(p,"d",` M 542.5 215.388 L 84 215.388 L 203 3 L 542.5 3 L 542.5 3 C\r
            714.422 3 854 142.578 854 314.5 C 854 486.422 714.422 626 542.5 626\r
            L 249 626 L 364 413.612 L 542.5 413.612 L 542.5 413.612 C 597.201\r
            413.612 641.612 369.201 641.612 314.5 C 641.612 259.799 597.201\r
            215.388 542.5 215.388 L 542.5 215.388 L 542.5 215.388 Z `),t(p,"fill","url(#_lgradient_3)"),t(p,"class","svelte-1mewqmc")},m(i,_){b(i,e,_),b(i,s,_),o(s,d),o(s,f),b(i,p,_),a=!0},p(i,_){},i(i){a||(i&&O(()=>{l||(l=C(e,q,{duration:k},!0)),l.run(1)}),i&&O(()=>{n||(n=C(p,q,{duration:k},!0)),n.run(1)}),a=!0)},o(i){i&&(l||(l=C(e,q,{duration:k},!1)),l.run(0)),i&&(n||(n=C(p,q,{duration:k},!1)),n.run(0)),a=!1},d(i){i&&y(e),i&&l&&l.end(),i&&y(s),i&&y(p),i&&n&&n.end()}}}function Y(g){let e;return{c(){e=L("h3"),e.textContent="Your app should probably have loaded by now"},m(l,s){b(l,e,s)},d(l){l&&y(e)}}}function M(g){let e,l,s,d,f,p,n,a,i,_,T,x,H,h,r=g[1]&&U(),c=g[2]&&Y();return{c(){e=L("div"),l=L("div"),s=u("svg"),d=u("defs"),f=u("clipPath"),p=u("rect"),n=u("g"),a=u("linearGradient"),i=u("stop"),_=u("stop"),r&&r.c(),T=P(),x=L("h1"),x.textContent="Generating routes...",H=P(),h=L("div"),c&&c.c(),t(p,"width","1000"),t(p,"height","1000"),t(f,"id","_clipPath_40vHZL606H8eXCPAFONHYpjfq1ISybTL"),t(i,"offset","1.7391304347826086%"),t(i,"stop-opacity","1"),v(i,"stop-color","rgb(255,124,247)"),t(_,"offset","100%"),t(_,"stop-opacity","1"),v(_,"stop-color","rgb(255,203,252)"),t(a,"id","_lgradient_2"),t(a,"x1","-0.011142038971568513"),t(a,"y1","-0.011791871475954507"),t(a,"x2","0.9938039543302696"),t(a,"y2","0.9909604299907665"),t(a,"gradientTransform","matrix(532,0,0,368.749,249,625.251)"),t(a,"gradientUnits","userSpaceOnUse"),t(n,"clip-path","url(#_clipPath_40vHZL606H8eXCPAFONHYpjfq1ISybTL)"),t(s,"xmlns","http://www.w3.org/2000/svg"),t(s,"xmlns:xlink","http://www.w3.org/1999/xlink"),v(s,"isolation","isolate"),t(s,"viewBox","0 0 1000 1000"),t(l,"class","svg svelte-1mewqmc"),G(l,"drawing",g[0]),t(x,"style",""),t(h,"class","error svelte-1mewqmc"),t(e,"class","container svelte-1mewqmc")},m(m,w){b(m,e,w),o(e,l),o(l,s),o(s,d),o(d,f),o(f,p),o(s,n),o(n,a),o(a,i),o(a,_),r&&r.m(n,null),o(e,T),o(e,x),o(e,H),o(e,h),c&&c.m(h,null)},p(m,[w]){m[1]?r?(r.p(m,w),w&2&&S(r,1)):(r=U(),r.c(),S(r,1),r.m(n,null)):r&&(A(),Z(r,1,1,()=>{r=null}),F()),w&1&&G(l,"drawing",m[0]),m[2]?c||(c=Y(),c.c(),c.m(h,null)):c&&(c.d(1),c=null)},i(m){S(r)},o(m){Z(r)},d(m){m&&y(e),r&&r.d(),c&&c.d()}}}let k=2e3;function N(g,e,l){let s=!0,d=!1,f=!1;return setTimeout(()=>l(1,d=!0)),setTimeout(()=>l(0,s=!1),1800),setTimeout(()=>l(2,f=!0),5e3),[s,d,f]}class K extends I{constructor(e){super(),X(this,e,N,M,j,{})}}export{K as default};