import{S as O,i as T,s as B,e as g,a as b,b as d,Y as y,c as q,d as v,D as E,n as k,f as C,z as j,E as x,g as L,a7 as z,u as I,t as K,a9 as M,aa as V,j as W,N as D,O as H,k as Y,m as F,o as G,p as w,q as A,P as S,H as J}from"./index.e9e1813c.js";function R(t,e,s){const l=t.slice();return l[6]=e[s][0],l[7]=e[s][1],l}function N(t){let e,s=t[7]+"",l,o,a;return{c(){e=g("a"),l=K(s),o=b(),d(e,"class","link svelte-15aixkh"),d(e,"href",a=t[2](t[6])),y(e,"active",t[1](t[6]))},m(n,i){q(n,e,i),v(e,l),v(e,o)},p(n,i){i&4&&a!==(a=n[2](n[6]))&&d(e,"href",a),i&10&&y(e,"active",n[1](n[6]))},d(n){n&&C(e)}}}function Q(t){let e,s,l,o,a,n,i,f,r,p,h,m=t[3],u=[];for(let c=0;c<m.length;c+=1)u[c]=N(R(t,m,c));return{c(){e=g("aside"),s=g("nav"),l=g("span"),l.textContent="\u2630",o=b(),a=g("span"),a.textContent="Routify Examples",n=b(),i=g("span"),f=b(),r=g("nav");for(let c=0;c<u.length;c+=1)u[c].c();d(l,"class","burger svelte-15aixkh"),d(a,"class","title svelte-15aixkh"),d(i,"class","svelte-15aixkh"),d(s,"class","mobile-nav svelte-15aixkh"),d(r,"class","svelte-15aixkh"),y(r,"show",t[0]),d(e,"class","svelte-15aixkh")},m(c,$){q(c,e,$),v(e,s),v(s,l),v(s,o),v(s,a),v(s,n),v(s,i),v(e,f),v(e,r);for(let _=0;_<u.length;_+=1)u[_].m(r,null);p||(h=[E(l,"click",t[4]),E(r,"click",t[5])],p=!0)},p(c,[$]){if($&14){m=c[3];let _;for(_=0;_<m.length;_+=1){const P=R(c,m,_);u[_]?u[_].p(P,$):(u[_]=N(P),u[_].c(),u[_].m(r,null))}for(;_<u.length;_+=1)u[_].d(1);u.length=m.length}$&1&&y(r,"show",c[0])},i:k,o:k,d(c){c&&C(e),j(u,c),p=!1,x(h)}}}function U(t,e,s){let l,o;L(t,z,r=>s(1,l=r)),L(t,I,r=>s(2,o=r));let a=!1;const n=[["/","\u2BC7 BACK TO APP"],["./index","Home"],["./modal","Modal"],["./reset","Reset"],["./layouts","Layouts"],["./widget","Widget"],["./aliasing","Aliasing"],["./404","404"],["./api","Api"],["./app","App"],["./transitions/tabs","Transitions"]];function i(){s(0,a=!a)}return[a,l,o,n,i,()=>s(0,a=!1)]}class X extends O{constructor(e){super(),T(this,e,U,Q,B,{})}}function Z(t){return{c:k,m:k,i:k,o:k,d:k}}function ee(t){let e,s,l;var o=t[2].default;function a(n){return{}}return o&&(e=new o(a())),{c(){e&&D(e.$$.fragment),s=J()},m(n,i){e&&H(e,n,i),q(n,s,i),l=!0},i(n){l||(e&&w(e.$$.fragment,n),l=!0)},o(n){e&&A(e.$$.fragment,n),l=!1},d(n){n&&C(s),e&&S(e,n)}}}function te(t){return{c:k,m:k,i:k,o:k,d:k}}function se(t){let e,s,l,o,a,n,i;l=new X({});let f={ctx:t,current:null,token:null,hasCatch:!1,pending:te,then:ee,catch:Z,value:2,blocks:[,,,]};M(V(()=>import("./RenderStatus.151ea0c1.js"),["assets/RenderStatus.151ea0c1.js","assets/RenderStatus.7811c0fe.css","assets/index.e9e1813c.js","assets/index.ca4fbbea.css","assets/index.c2f4aa2d.js"]),f);const r=t[1].default,p=W(r,t,t[0],null);return{c(){e=g("div"),s=g("div"),D(l.$$.fragment),o=b(),f.block.c(),a=b(),n=g("div"),p&&p.c(),d(s,"class","nav svelte-rq329u"),d(n,"class","main svelte-rq329u"),d(e,"class","example svelte-rq329u")},m(h,m){q(h,e,m),v(e,s),H(l,s,null),v(s,o),f.block.m(s,f.anchor=null),f.mount=()=>s,f.anchor=null,v(e,a),v(e,n),p&&p.m(n,null),i=!0},p(h,[m]){t=h,p&&p.p&&(!i||m&1)&&Y(p,r,t,t[0],i?G(r,t[0],m,null):F(t[0]),null)},i(h){i||(w(l.$$.fragment,h),w(f.block),w(p,h),i=!0)},o(h){A(l.$$.fragment,h);for(let m=0;m<3;m+=1){const u=f.blocks[m];A(u)}A(p,h),i=!1},d(h){h&&C(e),S(l),f.block.d(),f.token=null,f=null,p&&p.d(h)}}}function le(t,e,s){let{$$slots:l={},$$scope:o}=e;return t.$$set=a=>{"$$scope"in a&&s(0,o=a.$$scope)},[o,l]}class ae extends O{constructor(e){super(),T(this,e,le,se,B,{})}}export{ae as default};