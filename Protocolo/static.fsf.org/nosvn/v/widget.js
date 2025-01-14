/*
 * widget.js -- Fundraising web widget
 * Copyright (c) 2007 Creative Commons
 * Copyright (c) 2007 Free Software Foundation, Inc.
 *
 * Modified by the FSF in November 2007 to make it FSF-specific.
 * Modified by Matt Lee in November 2009 to update.
 *
 * Contains portions of Tinybox by Michael Leigeber under CC-BY 3.0
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *
 * A copy of the GNU Lesser General Public License is available at
 * <http://www.gnu.org/licenses/lgpl-3.0.html>.
 */

document.write('<a href="javascript:playvideo()"><img usemap="#fsf-widget" src=\'../../static.fsf.org/nosvn/v/' + fsf_widget_size + '-jra.png\'></a><style type=\"text/css\">#tinybox {position:absolute; display:none; -moz-border-radius: 0.5em; padding:0px; background:#fff url(images/preload.gif) no-repeat 50% 50%; border:10px solid #e3e3e3; z-index:2000} #tinymask {position:absolute; display:none; top:0; left:0; height:100%; width:100%; background:#000; z-index:1500} #tinycontent {background:#fff}</style>');


var TINY={};function T$(i){return document.getElementById(i)}TINY.box=function(){var p,m,b,fn,ic,iu,iw,ih,ia,f=0;return{show:function(c,u,w,h,a,t){if(!f){p=document.createElement('div');p.id='tinybox';m=document.createElement('div');m.id='tinymask';b=document.createElement('div');b.id='tinycontent';document.body.appendChild(m);document.body.appendChild(p);p.appendChild(b);m.onclick=TINY.box.hide;window.onresize=TINY.box.resize;f=1}if(!a&&!u){p.style.width=w?w+'px':'auto';p.style.height=h?h+'px':'auto';p.style.backgroundImage='none';b.innerHTML=c}else{b.style.display='none';p.style.width=p.style.height='100px'}this.mask();ic=c;iu=u;iw=w;ih=h;ia=a;this.alpha(m,1,80,3);if(t){setTimeout(function(){TINY.box.hide()},1000*t)}},fill:function(c,u,w,h,a){if(u){p.style.backgroundImage='';var x=window.XMLHttpRequest?new XMLHttpRequest():new ActiveXObject('Microsoft.XMLHTTP');x.onreadystatechange=function(){if(x.readyState==4&&x.status==200){TINY.box.psh(x.responseText,w,h,a)}};x.open('GET',c,1);x.send(null)}else{this.psh(c,w,h,a)}},psh:function(c,w,h,a){if(a){if(!w||!h){var x=p.style.width,y=p.style.height;b.innerHTML=c;p.style.width=w?w+'px':'';p.style.height=h?h+'px':'';b.style.display='';w=parseInt(b.offsetWidth);h=parseInt(b.offsetHeight);b.style.display='none';p.style.width=x;p.style.height=y}else{b.innerHTML=c}this.size(p,w,h,4)}else{p.style.backgroundImage='none'}},hide:function(){TINY.box.alpha(p,-1,0,3)},resize:function(){TINY.box.pos();TINY.box.mask()},mask:function(){m.style.height=TINY.page.theight()+'px';m.style.width='';m.style.width=TINY.page.twidth()+'px'},pos:function(){var t=(TINY.page.height()/2)-(p.offsetHeight/2);t=t<10?10:t;p.style.top=(t+TINY.page.top())+'px';p.style.left=(TINY.page.width()/2)-(p.offsetWidth/2)+'px'},alpha:function(e,d,a,s){clearInterval(e.ai);if(d==1){e.style.opacity=0;e.style.filter='alpha(opacity=0)';e.style.display='block';this.pos()}e.ai=setInterval(function(){TINY.box.twalpha(e,a,d,s)},20)},twalpha:function(e,a,d,s){var o=Math.round(e.style.opacity*100);if(o==a){clearInterval(e.ai);if(d==-1){e.style.display='none';e==p?TINY.box.alpha(m,-1,0,2):b.innerHTML=p.style.backgroundImage=''}else{e==m?this.alpha(p,1,100,5):TINY.box.fill(ic,iu,iw,ih,ia)}}else{var n=o+Math.ceil(Math.abs(a-o)/s)*d;e.style.opacity=n/100;e.style.filter='alpha(opacity='+n+')'}},size:function(e,w,h,s){e=typeof e=='object'?e:T$(e);clearInterval(e.si);var ow=e.offsetWidth,oh=e.offsetHeight,wo=ow-parseInt(e.style.width),ho=oh-parseInt(e.style.height);var wd=ow-wo>w?-1:1,hd=(oh-ho>h)?-1:1;e.si=setInterval(function(){TINY.box.twsize(e,w,wo,wd,h,ho,hd,s)},20)},twsize:function(e,w,wo,wd,h,ho,hd,s){var ow=e.offsetWidth-wo,oh=e.offsetHeight-ho;if(ow==w&&oh==h){clearInterval(e.si);p.style.backgroundImage='none';b.style.display='block'}else{if(ow!=w){e.style.width=ow+(Math.ceil(Math.abs(w-ow)/s)*wd)+'px'}if(oh!=h){e.style.height=oh+(Math.ceil(Math.abs(h-oh)/s)*hd)+'px'}this.pos()}}}}();TINY.page=function(){return{top:function(){return document.body.scrollTop||document.documentElement.scrollTop},width:function(){return self.innerWidth||document.documentElement.clientWidth},height:function(){return self.innerHeight||document.documentElement.clientHeight},theight:function(){var d=document,b=d.body,e=d.documentElement;return Math.max(Math.max(b.scrollHeight,e.scrollHeight),Math.max(b.clientHeight,e.clientHeight))},twidth:function(){var d=document,b=d.body,e=d.documentElement;return Math.max(Math.max(b.scrollWidth,e.scrollWidth),Math.max(b.clientWidth,e.clientWidth))}}}();


function playvideo(v) {

    TINY.box.show('<iframe src=\"../../static.fsf.org/nosvn/v/jra.html@r=' +  fsf_associate_id + '\" width=100% height=480 scrolling="no" frameborder="0">',0,480,480,1);

}