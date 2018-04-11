<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes" encoding="gb2312"/>
  <xsl:template match="/">
    <xsl:element name ="ufinterface">
      <xsl:attribute name ="billtype">A3</xsl:attribute>
      <xsl:attribute name ="filename"></xsl:attribute>
      <xsl:attribute name ="isexchange">Y</xsl:attribute>
      <xsl:attribute name ="operation">req</xsl:attribute>
      <xsl:attribute name ="proc">add</xsl:attribute>
      <xsl:attribute name ="receiver">101</xsl:attribute>
      <xsl:attribute name ="replace">N</xsl:attribute>
      <xsl:attribute name ="roottag">bill</xsl:attribute>
      <xsl:attribute name ="sender">1104</xsl:attribute>

      <xsl:element name ="bill">
        <xsl:attribute name ="id">
          <xsl:value-of select ="NewDataSet/M/pch"/>
        </xsl:attribute>
        <xsl:element name ="bill_head">
          <xsl:element name ="scddh">
            <xsl:value-of select="NewDataSet/M/scddh"/>
          </xsl:element>
          <xsl:element name ="zdrid">
            <xsl:value-of select="NewDataSet/M/zdrid"/>
          </xsl:element>          
          <xsl:element name ="pch">
            <xsl:value-of select="NewDataSet/M/pch"/>
          </xsl:element>
          <xsl:element name ="wlbmid">
            <xsl:value-of select="NewDataSet/M/wlbmid"/>
          </xsl:element>
          <xsl:element name ="jldwid">
            <xsl:value-of select="NewDataSet/M/jldwid"/>
          </xsl:element>
          <xsl:element name ="ylbmid">
            <xsl:value-of select="NewDataSet/M/ylbmid"/>
          </xsl:element>
          <xsl:element name ="bljhdh">
            <xsl:value-of select="NewDataSet/M/bljhdh"/>
          </xsl:element>
          <xsl:element name ="zdrq">
            <xsl:value-of select="NewDataSet/M/zdrq"/>
          </xsl:element>
          <xsl:element name ="freeitemvalue1">
            <xsl:value-of select="NewDataSet/M/freeitemvalue1"/>
          </xsl:element>
          <xsl:element name ="freeitemvalue2">
            <xsl:value-of select="NewDataSet/M/freeitemvalue2"/>
          </xsl:element>
          <xsl:element name ="freeitemvalue3">
            <xsl:value-of select="NewDataSet/M/freeitemvalue3"/>
          </xsl:element>
          <xsl:element name ="freeitemvalue4">
            <xsl:value-of select="NewDataSet/M/freeitemvalue4"/>
          </xsl:element>
          <xsl:element name ="freeitemvalue5">
            <xsl:value-of select="NewDataSet/M/freeitemvalue5"/>
          </xsl:element>
        </xsl:element>
        <xsl:element name ="bill_body">
          <xsl:for-each select="NewDataSet/s1">
            <xsl:element name ="item">
              <xsl:element name ="kgyid">
              <xsl:value-of select ="kgyid"/>
            </xsl:element>
              <xsl:element name ="ckckid">
                <xsl:value-of select ="ckckid"/>
              </xsl:element>
              <xsl:element name ="ckckbm">
                <xsl:value-of select ="ckckbm"/>
              </xsl:element>
              <xsl:element name ="wlbmid">
                <xsl:value-of select="wlbmid"/>
              </xsl:element>
              <xsl:element name ="jldwid">
                <xsl:value-of select="jldwid"/>
              </xsl:element>
              <xsl:element name ="fjldwid">
                <xsl:value-of select="fjldwid"/>
              </xsl:element>
              <xsl:element name ="ljcksl">
                <xsl:value-of select="ljcksl"/>
              </xsl:element>
              <xsl:element name ="fljcksl">
                <xsl:value-of select="fljcksl"/>
              </xsl:element>
              <xsl:element name ="pch">
                <xsl:value-of select="pch"/>
              </xsl:element>
              <xsl:element name ="gzzxid">
                <xsl:value-of select="gzzxid"/>
              </xsl:element>
              <xsl:element name ="gxh">
                <xsl:value-of select="gxh"/>
              </xsl:element>
              <xsl:element name ="zdy1">
                <xsl:value-of select="zdy1"/>
              </xsl:element>
              <xsl:element name ="zdy2">
                <xsl:value-of select="zdy2"/>
              </xsl:element>
              <xsl:element name ="zdy3">
                <xsl:value-of select="zdy3"/>
              </xsl:element>
              <xsl:element name ="zdy4">
                <xsl:value-of select="zdy4"/>
              </xsl:element>
              <xsl:element name ="zdy5">
                <xsl:value-of select="zdy5"/>
              </xsl:element>
              <xsl:element name ="freeitemvalue1">
                <xsl:value-of select="zyx1"/>
              </xsl:element>
              <xsl:element name ="freeitemvalue2">
                <xsl:value-of select="zyx2"/>
              </xsl:element>
              <xsl:element name ="freeitemvalue3">
                <xsl:value-of select="zyx3"/>
              </xsl:element>
              <xsl:element name ="freeitemvalue4">
                <xsl:value-of select="zyx4"/>
              </xsl:element>
              <xsl:element name ="freeitemvalue5">
                <xsl:value-of select="zyx5"/>
              </xsl:element>
              <xsl:element name ="pk_corp">
                <xsl:value-of select="pk_corp"/>
              </xsl:element>
              <xsl:element name ="gcbm">
                <xsl:value-of select="gcbm"/>
              </xsl:element>
              <xsl:element name ="ccostobject">
                <xsl:value-of select="ccostobject"/>
              </xsl:element>
              <xsl:element name ="flrq">
                <xsl:value-of select="flrq"/>
              </xsl:element>
              <xsl:element name="pk_moid">
                <xsl:value-of select="pk_moid"/>
              </xsl:element>            
            </xsl:element>
          </xsl:for-each>
        </xsl:element>
      </xsl:element>
    </xsl:element>
  </xsl:template>
</xsl:stylesheet>