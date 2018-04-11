<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" version="1.0" encoding="gb2312" omit-xml-declaration="no" indent="yes" media-type="string"/>
  
  <xsl:template match="/">
    <xsl:element name="ufinterface">
      <xsl:attribute name="billtype">A2</xsl:attribute>
      <xsl:attribute name="filename"></xsl:attribute>
      <xsl:attribute name="isexchange">Y</xsl:attribute>
      <xsl:attribute name="operation">req</xsl:attribute>
      <xsl:attribute name="proc">add</xsl:attribute>
      <xsl:attribute name="receiver">101</xsl:attribute>
      <xsl:attribute name="replace">N</xsl:attribute>
      <xsl:attribute name="roottag">bill</xsl:attribute>
      <xsl:attribute name="sender">1104</xsl:attribute>

      <xsl:for-each select="//L3DataTable">
        <xsl:element name="bill">
          <xsl:attribute name="id">
            <xsl:value-of select="./pch"/>
          </xsl:attribute>
          <xsl:element name="bill_head">
            <xsl:element name="scddh">
              <xsl:value-of select="./scddh"/>
            </xsl:element>
            <xsl:element name="pk_poid">
              <xsl:value-of select="./pk_poid"/>
            </xsl:element>
            <xsl:element name="jhddh">
              <xsl:value-of select="./jhddh"/>
            </xsl:element>
            <xsl:element name="wlbmid">
              <xsl:value-of select="./wlbmid"/>
            </xsl:element>
            <xsl:element name="pk_produce">
              <xsl:value-of select="./pk_produce"/>
            </xsl:element>
            <xsl:element name="invcode">
              <xsl:value-of select="./invcode"/>
            </xsl:element>
            <xsl:element name="invname">
              <xsl:value-of select="./invname"/>
            </xsl:element>
            <xsl:element name="pch">
              <xsl:value-of select="./pch"/>
            </xsl:element>
            <xsl:element name="scbmid">
              <xsl:value-of select="./scbmid"/>
            </xsl:element>
            <xsl:element name="gzzxid">
              <xsl:value-of select="./gzzxid"/>
            </xsl:element>
            <xsl:element name="gzzxbm">
              <xsl:value-of select="./gzzxbm"/>
            </xsl:element>
            <xsl:element name="ksid">
              <xsl:value-of select="./ksid"/>
            </xsl:element>
            <xsl:element name="memo">
              <xsl:value-of select="./memo"/>
            </xsl:element>
            <xsl:element name="sfjj">
              <xsl:value-of select="./sfjj"/>
            </xsl:element>
            <xsl:element name="yxj">
              <xsl:value-of select="./yxj"/>
            </xsl:element>
            <xsl:element name="bcid">
              <xsl:value-of select="./bcid"/>
            </xsl:element>
            <xsl:element name="bzid">
              <xsl:value-of select="./bzid"/>
            </xsl:element>
            <xsl:element name="jhkgrq">
              <xsl:value-of select="./jhkgrq"/>
            </xsl:element>
            <xsl:element name="jhwgrq">
              <xsl:value-of select="./jhwgrq"/>
            </xsl:element>
            <xsl:element name="jhkssj">
              <xsl:value-of select="./jhkssj"/>
            </xsl:element>
            <xsl:element name="jhjssj">
              <xsl:value-of select="./jhjssj"/>
            </xsl:element>
            <xsl:element name="sjkgrq">
              <xsl:value-of select="./sjkgrq"/>
            </xsl:element>
            <xsl:element name="sjwgrq">
              <xsl:value-of select="./sjwgrq"/>
            </xsl:element>
            <xsl:element name="sjkssj">
              <xsl:value-of select="./sjkssj"/>
            </xsl:element>
            <xsl:element name="sjjssj">
              <xsl:value-of select="./sjjssj"/>
            </xsl:element>
            <xsl:element name="jhwgsl">
              <xsl:value-of select="./jhwgsl"/>
            </xsl:element>
            <xsl:element name="fjhsl">
              <xsl:value-of select="./fjhsl"/>
            </xsl:element>
            <xsl:element name="jldwid">
              <xsl:value-of select="./jldwid"/>
            </xsl:element>
            <xsl:element name="fjlid">
              <xsl:value-of select="./fjlid"/>
            </xsl:element>
            <xsl:element name="sjwgsl">
              <xsl:value-of select="./sjwgsl"/>
            </xsl:element>
            <xsl:element name="fwcsl">
              <xsl:value-of select="./fwcsl"/>
            </xsl:element>
            <xsl:element name="zdy1">
              <xsl:value-of select="./zdy1"/>
            </xsl:element>
            <xsl:element name="zdy2">
              <xsl:value-of select="./zdy2"/>
            </xsl:element>
            <xsl:element name="zdy3">
              <xsl:value-of select="./zdy3"/>
            </xsl:element>
            <xsl:element name="zdy4">
              <xsl:value-of select="./zdy4"/>
            </xsl:element>
            <xsl:element name="zdy5">
              <xsl:value-of select="./zdy5"/>
            </xsl:element>
            <xsl:element name="freeitemvalue1">
              <xsl:value-of select="./zyx1"/>
            </xsl:element>
            <xsl:element name="freeitemvalue2">
              <xsl:value-of select="./zyx2"/>
            </xsl:element>
            <xsl:element name="freeitemvalue3">
              <xsl:value-of select="./zyx3"/>
            </xsl:element>
            <xsl:element name="freeitemvalue4">
              <xsl:value-of select="./zyx4"/>
            </xsl:element>
            <xsl:element name="freeitemvalue5">
              <xsl:value-of select="./zyx5"/>
            </xsl:element>
            <xsl:element name="pk_corp">
              <xsl:value-of select="./pk_corp"/>
            </xsl:element>
            <xsl:element name="gcbm">
              <xsl:value-of select="./gcbm"/>
            </xsl:element>
            <xsl:element name="zdrid">
              <xsl:value-of select="./zdrid"/>
            </xsl:element>
            <xsl:element name="pk_moid">
              <xsl:value-of select="./pk_moid"/>
            </xsl:element>
          </xsl:element>
        </xsl:element>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>

</xsl:stylesheet>