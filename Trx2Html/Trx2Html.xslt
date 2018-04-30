<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    
				xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	xmlns:s="http://microsoft.com/schemas/VisualStudio/TeamTest/2010"
	exclude-result-prefixes="msxsl s" 
	>
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/">
		<html>
			<head>
				
				<script language="javascript" src="http://code.jquery.com/jquery-latest.js"></script>
				
				<style type="text/css">
					a:link { text-decoration: none; }
					a:visited { text-decoration: none; }
					a:hover { text-decoration: underline; }
					a:active { text-decoration: underline; }
					a:link { color: rgb(12, 103, 219); }
					a:visited { color: rgb(12, 103, 219); }
					a:hover { color: rgb(12, 103, 219); }
					a:active { color: rgb(12, 103, 219); }

					html
					{
					font-family: Segoe UI;
					font-size:10pt;
					}

					h1
					{
					font-size: 20pt;
					}

					#navigation
					{
					font-size:10pt;
					}
					.topLink
					{
					margin-top: 10px;
					font-size:10pt;
					}

					#info tr, #info th, #info tr td
					{
					border:0px;
					}

					#summary tr, #summary th, #summary tr td
					{
					border:1px solid black;
					}

					.content tr, .content th, .content tr td
					{
					border-left:0px; border-top:1px solid black; border-bottom:0px; border-right:0px;
					}
					.content th
					{
					padding:7px 5px 7px 5px;
					background-color:black; color:white;
					}

					table, th, tr, td
					{
					border-collapse:collapse;
					font-family:  Segoe UI;
					font-size: 10pt;
					text-align: left;
					vertical-align:top;
					padding:3px 6px 3px 6px;
					horizontal-align:left;
					min-width:70px;
					}
					table tr:hover
					{
					background-color:rgb(255, 255, 173);
					}

					.hidden
					{
					display:none;
					font-size:9pt;
					}
					.show
					{
					display:block;
					font-size:9pt;
					}
					.toggle
					{
					color: rgb(12, 103, 219);
					}
					.toggle:hover
					{
					cursor:hand;
					text-decoration:underline;
					}
					.sorttable_sort
					{
					cursor:hand;
					}

				</style>

				<script language="javascript" type="text/javascript">
					function OnToggleClicked(id)
						{
							// toggle details
							$('#div_' +id).slideToggle(300, function() {
								// Animation complete.
								// change display test
							});
						}
				</script>

				<script>
					<xsl:comment>
						<![CDATA[
					/*
  SortTable
  version 2
  7th April 2007
  Stuart Langridge, http://www.kryogenix.org/code/browser/sorttable/

  Instructions:
  Download this file
  Add <script src="sorttable.js"></script> to your HTML
  Add class="sortable" to any table you'd like to make sortable
  Click on the headers to sort

  Thanks to many, many people for contributions and suggestions.
  Licenced as X11: http://www.kryogenix.org/code/browser/licence.html
  This basically means: do what you want with it.
*/


var stIsIE = /*@cc_on!@*/false;

sorttable = {
  init: function() {
    // quit if this function has already been called
    if (arguments.callee.done) return;
    // flag this function so we don't do the same thing twice
    arguments.callee.done = true;
    // kill the timer
    if (_timer) clearInterval(_timer);

    if (!document.createElement || !document.getElementsByTagName) return;

    sorttable.DATE_RE = /^(\d\d?)[\/\.-](\d\d?)[\/\.-]((\d\d)?\d\d)$/;

    forEach(document.getElementsByTagName('table'), function(table) {
      if (table.className.search(/\bsortable\b/) != -1) {
        sorttable.makeSortable(table);
      }
    });

  },

  makeSortable: function(table) {
    if (table.getElementsByTagName('thead').length == 0) {
      // table doesn't have a tHead. Since it should have, create one and
      // put the first table row in it.
      the = document.createElement('thead');
      the.appendChild(table.rows[0]);
      table.insertBefore(the,table.firstChild);
    }
    // Safari doesn't support table.tHead, sigh
    if (table.tHead == null) table.tHead = table.getElementsByTagName('thead')[0];

    if (table.tHead.rows.length != 1) return; // can't cope with two header rows

    // Sorttable v1 put rows with a class of "sortbottom" at the bottom (as
    // "total" rows, for example). This is B&R, since what you're supposed
    // to do is put them in a tfoot. So, if there are sortbottom rows,
    // for backwards compatibility, move them to tfoot (creating it if needed).
    sortbottomrows = [];
    for (var i=0; i<table.rows.length; i++) {
      if (table.rows[i].className.search(/\bsortbottom\b/) != -1) {
        sortbottomrows[sortbottomrows.length] = table.rows[i];
      }
    }
    if (sortbottomrows) {
      if (table.tFoot == null) {
        // table doesn't have a tfoot. Create one.
        tfo = document.createElement('tfoot');
        table.appendChild(tfo);
      }
      for (var i=0; i<sortbottomrows.length; i++) {
        tfo.appendChild(sortbottomrows[i]);
      }
      delete sortbottomrows;
    }

    // work through each column and calculate its type
    headrow = table.tHead.rows[0].cells;
    for (var i=0; i<headrow.length; i++) {
      // manually override the type with a sorttable_type attribute
      if (!headrow[i].className.match(/\bsorttable_nosort\b/)) { // skip this col
        mtch = headrow[i].className.match(/\bsorttable_([a-z0-9]+)\b/);
        if (mtch) { override = mtch[1]; }
	      if (mtch && typeof sorttable["sort_"+override] == 'function') {
	        headrow[i].sorttable_sortfunction = sorttable["sort_"+override];
	      } else {
	        headrow[i].sorttable_sortfunction = sorttable.guessType(table,i);
	      }
	      // make it clickable to sort
	      headrow[i].sorttable_columnindex = i;
	      headrow[i].sorttable_tbody = table.tBodies[0];
	      dean_addEvent(headrow[i],"click", sorttable.innerSortFunction = function(e) {

          if (this.className.search(/\bsorttable_sorted\b/) != -1) {
            // if we're already sorted by this column, just
            // reverse the table, which is quicker
            sorttable.reverse(this.sorttable_tbody);
            this.className = this.className.replace('sorttable_sorted',
                                                    'sorttable_sorted_reverse');
            this.removeChild(document.getElementById('sorttable_sortfwdind'));
            sortrevind = document.createElement('span');
            sortrevind.id = "sorttable_sortrevind";
            sortrevind.innerHTML = stIsIE ? '&nbsp<font face="webdings">5</font>' : '&nbsp;&#x25B4;';
            this.appendChild(sortrevind);
            return;
          }
          if (this.className.search(/\bsorttable_sorted_reverse\b/) != -1) {
            // if we're already sorted by this column in reverse, just
            // re-reverse the table, which is quicker
            sorttable.reverse(this.sorttable_tbody);
            this.className = this.className.replace('sorttable_sorted_reverse',
                                                    'sorttable_sorted');
            this.removeChild(document.getElementById('sorttable_sortrevind'));
            sortfwdind = document.createElement('span');
            sortfwdind.id = "sorttable_sortfwdind";
            sortfwdind.innerHTML = stIsIE ? '&nbsp<font face="webdings">6</font>' : '&nbsp;&#x25BE;';
            this.appendChild(sortfwdind);
            return;
          }

          // remove sorttable_sorted classes
          theadrow = this.parentNode;
          forEach(theadrow.childNodes, function(cell) {
            if (cell.nodeType == 1) { // an element
              cell.className = cell.className.replace('sorttable_sorted_reverse','');
              cell.className = cell.className.replace('sorttable_sorted','');
            }
          });
          sortfwdind = document.getElementById('sorttable_sortfwdind');
          if (sortfwdind) { sortfwdind.parentNode.removeChild(sortfwdind); }
          sortrevind = document.getElementById('sorttable_sortrevind');
          if (sortrevind) { sortrevind.parentNode.removeChild(sortrevind); }

          this.className += ' sorttable_sorted';
          sortfwdind = document.createElement('span');
          sortfwdind.id = "sorttable_sortfwdind";
          sortfwdind.innerHTML = stIsIE ? '&nbsp<font face="webdings">6</font>' : '&nbsp;&#x25BE;';
          this.appendChild(sortfwdind);

	        // build an array to sort. This is a Schwartzian transform thing,
	        // i.e., we "decorate" each row with the actual sort key,
	        // sort based on the sort keys, and then put the rows back in order
	        // which is a lot faster because you only do getInnerText once per row
	        row_array = [];
	        col = this.sorttable_columnindex;
	        rows = this.sorttable_tbody.rows;
	        for (var j=0; j<rows.length; j++) {
	          row_array[row_array.length] = [sorttable.getInnerText(rows[j].cells[col]), rows[j]];
	        }
	        /* If you want a stable sort, uncomment the following line */
	        //sorttable.shaker_sort(row_array, this.sorttable_sortfunction);
	        /* and comment out this one */
	        row_array.sort(this.sorttable_sortfunction);

	        tb = this.sorttable_tbody;
	        for (var j=0; j<row_array.length; j++) {
	          tb.appendChild(row_array[j][1]);
	        }

	        delete row_array;
	      });
	    }
    }
  },

  guessType: function(table, column) {
    // guess the type of a column based on its first non-blank row
    sortfn = sorttable.sort_alpha;
    for (var i=0; i<table.tBodies[0].rows.length; i++) {
      text = sorttable.getInnerText(table.tBodies[0].rows[i].cells[column]);
      if (text != '') {
        if (text.match(/^-?[£$¤]?[\d,.]+%?$/)) {
          return sorttable.sort_numeric;
        }
        // check for a date: dd/mm/yyyy or dd/mm/yy
        // can have / or . or - as separator
        // can be mm/dd as well
        possdate = text.match(sorttable.DATE_RE)
        if (possdate) {
          // looks like a date
          first = parseInt(possdate[1]);
          second = parseInt(possdate[2]);
          if (first > 12) {
            // definitely dd/mm
            return sorttable.sort_ddmm;
          } else if (second > 12) {
            return sorttable.sort_mmdd;
          } else {
            // looks like a date, but we can't tell which, so assume
            // that it's dd/mm (English imperialism!) and keep looking
            sortfn = sorttable.sort_ddmm;
          }
        }
      }
    }
    return sortfn;
  },

  getInnerText: function(node) {
    // gets the text we want to use for sorting for a cell.
    // strips leading and trailing whitespace.
    // this is *not* a generic getInnerText function; it's special to sorttable.
    // for example, you can override the cell text with a customkey attribute.
    // it also gets .value for <input> fields.

    if (!node) return "";

    hasInputs = (typeof node.getElementsByTagName == 'function') &&
                 node.getElementsByTagName('input').length;

    if (node.getAttribute("sorttable_customkey") != null) {
      return node.getAttribute("sorttable_customkey");
    }
    else if (typeof node.textContent != 'undefined' && !hasInputs) {
      return node.textContent.replace(/^\s+|\s+$/g, '');
    }
    else if (typeof node.innerText != 'undefined' && !hasInputs) {
      return node.innerText.replace(/^\s+|\s+$/g, '');
    }
    else if (typeof node.text != 'undefined' && !hasInputs) {
      return node.text.replace(/^\s+|\s+$/g, '');
    }
    else {
      switch (node.nodeType) {
        case 3:
          if (node.nodeName.toLowerCase() == 'input') {
            return node.value.replace(/^\s+|\s+$/g, '');
          }
        case 4:
          return node.nodeValue.replace(/^\s+|\s+$/g, '');
          break;
        case 1:
        case 11:
          var innerText = '';
          for (var i = 0; i < node.childNodes.length; i++) {
            innerText += sorttable.getInnerText(node.childNodes[i]);
          }
          return innerText.replace(/^\s+|\s+$/g, '');
          break;
        default:
          return '';
      }
    }
  },

  reverse: function(tbody) {
    // reverse the rows in a tbody
    newrows = [];
    for (var i=0; i<tbody.rows.length; i++) {
      newrows[newrows.length] = tbody.rows[i];
    }
    for (var i=newrows.length-1; i>=0; i=i-1 ) {
       tbody.appendChild(newrows[i]);
    }
    delete newrows;
  },

  /* sort functions
     each sort function takes two parameters, a and b
     you are comparing a[0] and b[0] */
  sort_numeric: function(a,b) {
    aa = parseFloat(a[0].replace(/[^0-9.-]/g,''));
    if (isNaN(aa)) aa = 0;
    bb = parseFloat(b[0].replace(/[^0-9.-]/g,''));
    if (isNaN(bb)) bb = 0;
    return aa-bb;
  },
  sort_alpha: function(a,b) {
    if (a[0]==b[0]) return 0;
    if (a[0]<b[0]) return -1;
    return 1;
  },
  sort_ddmm: function(a,b) {
    mtch = a[0].match(sorttable.DATE_RE);
    y = mtch[3]; m = mtch[2]; d = mtch[1];
    if (m.length == 1) m = '0'+m;
    if (d.length == 1) d = '0'+d;
    dt1 = y+m+d;
    mtch = b[0].match(sorttable.DATE_RE);
    y = mtch[3]; m = mtch[2]; d = mtch[1];
    if (m.length == 1) m = '0'+m;
    if (d.length == 1) d = '0'+d;
    dt2 = y+m+d;
    if (dt1==dt2) return 0;
    if (dt1<dt2) return -1;
    return 1;
  },
  sort_mmdd: function(a,b) {
    mtch = a[0].match(sorttable.DATE_RE);
    y = mtch[3]; d = mtch[2]; m = mtch[1];
    if (m.length == 1) m = '0'+m;
    if (d.length == 1) d = '0'+d;
    dt1 = y+m+d;
    mtch = b[0].match(sorttable.DATE_RE);
    y = mtch[3]; d = mtch[2]; m = mtch[1];
    if (m.length == 1) m = '0'+m;
    if (d.length == 1) d = '0'+d;
    dt2 = y+m+d;
    if (dt1==dt2) return 0;
    if (dt1<dt2) return -1;
    return 1;
  },

  shaker_sort: function(list, comp_func) {
    // A stable sort function to allow multi-level sorting of data
    // see: http://en.wikipedia.org/wiki/Cocktail_sort
    // thanks to Joseph Nahmias
    var b = 0;
    var t = list.length - 1;
    var swap = true;

    while(swap) {
        swap = false;
        for(var i = b; i < t; ++i) {
            if ( comp_func(list[i], list[i+1]) > 0 ) {
                var q = list[i]; list[i] = list[i+1]; list[i+1] = q;
                swap = true;
            }
        } // for
        t=t-1;

        if (!swap) break;

        for(var i = t; i > b; i=i-1) {
            if ( comp_func(list[i], list[i-1]) < 0 ) {
                var q = list[i]; list[i] = list[i-1]; list[i-1] = q;
                swap = true;
            }
        } // for
        b++;

    } // while(swap)
  }
}

/* ******************************************************************
   Supporting functions: bundled here to avoid depending on a library
   ****************************************************************** */

// Dean Edwards/Matthias Miller/John Resig

/* for Mozilla/Opera9 */
if (document.addEventListener) {
    document.addEventListener("DOMContentLoaded", sorttable.init, false);
}

/* for Internet Explorer */
/*@cc_on @*/
/*@if (@_win32)
    document.write("<script id=__ie_onload defer src=javascript:void(0)><\/script>");
    var script = document.getElementById("__ie_onload");
    script.onreadystatechange = function() {
        if (this.readyState == "complete") {
            sorttable.init(); // call the onload handler
        }
    };
/*@end @*/

/* for Safari */
if (/WebKit/i.test(navigator.userAgent)) { // sniff
    var _timer = setInterval(function() {
        if (/loaded|complete/.test(document.readyState)) {
            sorttable.init(); // call the onload handler
        }
    }, 10);
}

/* for other browsers */
window.onload = sorttable.init;

// written by Dean Edwards, 2005
// with input from Tino Zijdel, Matthias Miller, Diego Perini

// http://dean.edwards.name/weblog/2005/10/add-event/

function dean_addEvent(element, type, handler) {
	if (element.addEventListener) {
		element.addEventListener(type, handler, false);
	} else {
		// assign each event handler a unique ID
		if (!handler.$$guid) handler.$$guid = dean_addEvent.guid++;
		// create a hash table of event types for the element
		if (!element.events) element.events = {};
		// create a hash table of event handlers for each element/event pair
		var handlers = element.events[type];
		if (!handlers) {
			handlers = element.events[type] = {};
			// store the existing event handler (if there is one)
			if (element["on" + type]) {
				handlers[0] = element["on" + type];
			}
		}
		// store the event handler in the hash table
		handlers[handler.$$guid] = handler;
		// assign a global event handler to do all the work
		element["on" + type] = handleEvent;
	}
};
// a counter used to create unique IDs
dean_addEvent.guid = 1;

function removeEvent(element, type, handler) {
	if (element.removeEventListener) {
		element.removeEventListener(type, handler, false);
	} else {
		// delete the event handler from the hash table
		if (element.events && element.events[type]) {
			delete element.events[type][handler.$$guid];
		}
	}
};

function handleEvent(event) {
	var returnValue = true;
	// grab the event object (IE uses a global event object)
	event = event || fixEvent(((this.ownerDocument || this.document || this).parentWindow || window).event);
	// get a reference to the hash table of event handlers
	var handlers = this.events[event.type];
	// execute each event handler
	for (var i in handlers) {
		this.$$handleEvent = handlers[i];
		if (this.$$handleEvent(event) === false) {
			returnValue = false;
		}
	}
	return returnValue;
};

function fixEvent(event) {
	// add W3C standard event methods
	event.preventDefault = fixEvent.preventDefault;
	event.stopPropagation = fixEvent.stopPropagation;
	return event;
};
fixEvent.preventDefault = function() {
	this.returnValue = false;
};
fixEvent.stopPropagation = function() {
  this.cancelBubble = true;
}

// Dean's forEach: http://dean.edwards.name/base/forEach.js
/*
	forEach, version 1.0
	Copyright 2006, Dean Edwards
	License: http://www.opensource.org/licenses/mit-license.php
*/

// array-like enumeration
if (!Array.forEach) { // mozilla already supports this
	Array.forEach = function(array, block, context) {
		for (var i = 0; i < array.length; i++) {
			block.call(context, array[i], i, array);
		}
	};
}

// generic enumeration
Function.prototype.forEach = function(object, block, context) {
	for (var key in object) {
		if (typeof this.prototype[key] == "undefined") {
			block.call(context, object[key], key, object);
		}
	}
};

// character enumeration
String.forEach = function(string, block, context) {
	Array.forEach(string.split(""), function(chr, index) {
		block.call(context, chr, index, string);
	});
};

// globally resolve forEach enumeration
var forEach = function(object, block, context) {
	if (object) {
		var resolve = Object; // default
		if (object instanceof Function) {
			// functions have a "length" property
			resolve = Function;
		} else if (object.forEach instanceof Function) {
			// the object implements a custom forEach method so use that
			object.forEach(block, context);
			return;
		} else if (typeof object == "string") {
			// the object is a string
			resolve = String;
		} else if (typeof object.length == "number") {
			// the object is array-like
			resolve = Array;
		}
		resolve.forEach(object, block, context);
	}
};

]]>
					</xsl:comment>
				</script>

			</head>
			<body>

				<!-- Navigation -->
				<a name="navigation">
					<div id="navigation">
						<a href="#info">Summary </a>
						<a href="#passed">Passed </a>
						<a href="#failed">Failed </a>
					</div>
				</a>

				<!-- Summary -->
				<h1>
					<a name="info">Summary</a>
				</h1>
				<table id="info" border="0">
					<tbody>
						<tr>
							<td>
								Test Run Result:
							</td>
							<td>
								<xsl:apply-templates select="s:TestRun/s:ResultSummary/@outcome"/>
							</td>
						</tr>
						<tr>
							<td>
								User Name:
							</td>
							<td>
								<xsl:apply-templates select="s:TestRun/@runUser"/>
							</td>
						</tr>
						<tr>
							<td>
								Computer Name:
							</td>
							<td>
								<xsl:apply-templates select="s:TestRun/s:Results/s:UnitTestResult[1]/@computerName"/>
							</td>
						</tr>
						<tr>
							<td>
								Settings File:
							</td>
							<td>
								<xsl:apply-templates select="s:TestRun/s:TestSettings/@name"/>
							</td>
						</tr>
						<tr>
							<td>
								Original TRX File:
							</td>
							<td>
								<xsl:apply-templates select="s:TestRun/@name"/>
							</td>
						</tr>
						<tr>
							<td>
								Deployment Folder:
							</td>
							<td>
								<xsl:apply-templates select="s:TestRun/s:TestSettings/s:Deployment/@userDeploymentRoot"/>
							</td>
						</tr>
					</tbody>
				</table>
				<br/>
				<table id="summary">
					<thead>
						<tr>
							<th>Total</th>
							<th>Executed</th>
							<th style="background-color: lightgreen;">Passed</th>
							<th style="background-color: lightcoral;">Failed</th>
						</tr>
					</thead>
					<tbody>
						<tr>
							<xsl:variable name="executed">
								<xsl:value-of select="s:TestRun/s:ResultSummary/s:Counters/@executed"/>
							</xsl:variable>
							<xsl:variable name="passed">
								<xsl:value-of select="s:TestRun/s:ResultSummary/s:Counters/@passed"/>
							</xsl:variable>
							<xsl:variable name="failed">
								<xsl:value-of select="s:TestRun/s:ResultSummary/s:Counters/@failed"/>
							</xsl:variable>
							<td>
								<xsl:apply-templates select="s:TestRun/s:ResultSummary/s:Counters/@total"/>
							</td>
							<td>
								<xsl:value-of select="$executed"/>
							</td>
							<td>
								<xsl:value-of select="$passed"/>
								<br/>
								<xsl:value-of select="format-number($passed div $executed * 100, '0.00')"/> %
							</td>
							<td>
								<xsl:value-of select="$failed"/>
								<br/>
								<xsl:value-of select="format-number($failed div $executed * 100, '0.00')"/> %
							</td>
						</tr>
					</tbody>
				</table>
				<div class="topLink">
					<a href="#navigation">Back to Top</a>
				</div>

				<!-- Passed -->
				<h1>
					<a name="passed">Passed</a>
				</h1>
				<div id="passed">
					<table class="sortable content">
						<thead>
							<tr>
								<th class="sorttable_nosort">Result</th>
								<th class="sorttable_sort">Test Name</th>
								<th class="sorttable_sort">Test List</th>
								<th class="sorttable_nosort">Duration</th>
								<th class="sorttable_sort">Owner</th>
							</tr>
						</thead>
						<tbody>
							<xsl:for-each select="s:TestRun/s:Results/s:UnitTestResult">
								<xsl:if test="@outcome = 'Passed'">
									<tr>
										<td>
											<xsl:value-of select="@outcome"/>
										</td>
										<td>
											<xsl:value-of select="@testName"/>
										</td>
										<xsl:variable name="testId">
											<xsl:value-of select="@testId"/>
										</xsl:variable>
										<td>
											<xsl:variable name ="testListId" select="/s:TestRun/s:TestEntries/s:TestEntry[@testId=$testId]/@testListId"/>
											<xsl:variable name ="testListName" select="/s:TestRun/s:TestLists/s:TestList[@id=$testListId]/@name"/>
											<xsl:value-of select ="$testListName"/>
										</td>
										<td>
											<xsl:value-of select="@duration"/>
										</td>
										<td>
											<xsl:variable name ="owner" select="/s:TestRun/s:TestDefinitions/s:UnitTest[@id=$testId]/s:Owners/s:Owner/@name"/>
											<a href="mailto:{$owner}">
												<xsl:value-of select ="$owner"/>
											</a>
										</td>
									</tr>
								</xsl:if>
							</xsl:for-each>
						</tbody>
					</table>
					<div class="topLink">
						<a href="#navigation">Back to Top</a>
					</div>
				</div>

				<!-- Failed -->
				<h1>
					<a name="failed">Failed</a>
				</h1>
				<div id="failed">
					<table class="sortable content">
						<thead>
							<tr>
								<th class="sorttable_nosort">Result</th>
								<th class="sorttable_sort">Test Name</th>
								<th class="sorttable_sort">Test List</th>
								<th class="sorttable_sort">Owner</th>
								<th class="sorttable_nosort">
									<br/>
								</th>
							</tr>
						</thead>
						<tbody>
							<xsl:for-each select="s:TestRun/s:Results/s:UnitTestResult">
								<xsl:if test="@outcome = 'Failed'">
									<tr>
										<td>
											<xsl:value-of select="@outcome"/>
										</td>
										<td>
											<xsl:value-of select="@testName"/>
										</td>
										<xsl:variable name="testId">
											<xsl:value-of select="@testId"/>
										</xsl:variable>
										<td >
											<xsl:variable name ="testListId" select="/s:TestRun/s:TestEntries/s:TestEntry[@testId=$testId]/@testListId"/>
											<xsl:variable name ="testListName" select="/s:TestRun/s:TestLists/s:TestList[@id=$testListId]/@name"/>
											<xsl:value-of select ="$testListName"/>
										</td>
										<xsl:variable name="message">
											<xsl:value-of select="s:Output/s:ErrorInfo/s:Message"/>
										</xsl:variable>
										<xsl:variable name="callstack">
											<xsl:value-of select="s:Output/s:ErrorInfo/s:StackTrace"/>
										</xsl:variable>
										<td>
											<xsl:variable name ="owner" select="/s:TestRun/s:TestDefinitions/s:UnitTest[@id=$testId]/s:Owners/s:Owner/@name"/>
											<a href="mailto:{$owner}">
												<xsl:value-of select ="$owner"/>
											</a>
										</td>
										<td>
											<div id="text_{$testId}" onclick="javascript:OnToggleClicked('{$testId}')" class="toggle">Details</div>
											<div id="div_{$testId}" class="hidden">
												<p>
													<b>Message</b>
													<br/><xsl:value-of select="$message"/>
												</p>
												<p>
													<b>Call Stack</b>
													<br/><xsl:value-of select="$callstack"/>
												</p>
											</div>

										</td>
									</tr>
								</xsl:if>
							</xsl:for-each>
						</tbody>
					</table>
					<div class="topLink">
						<a href="#navigation">Back to Top</a>
					</div>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
