<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes" encoding="gb2312"/>
  <xsl:template match="/">
    <xsl:element name ="ufinterface">
      <xsl:attribute name ="billtype">TSA4</xsl:attribute>
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
          <xsl:element name ="zdrid">
            <xsl:value-of select="NewDataSet/M/zdrid"/>
          </xsl:element>
          <xsl:element name ="rq">
            <xsl:value-of select="NewDataSet/M/rq"/>
          </xsl:element>
          <xsl:element name ="sj">
            <xsl:value-of select="NewDataSet/M/sj"/>
          </xsl:element>
        </xsl:element>
        <xsl:element name ="bill_body">
          <xsl:for-each select="NewDataSet/s1">
            <xsl:element name ="item">
              <xsl:element name ="wlbmid">
                <xsl:value-of select="wlbmid"/>
              </xsl:element>
              <xsl:element name ="jldwid">
                <xsl:value-of select="jldwid"/>
              </xsl:element>
              <xsl:element name ="gzzxid">
                <xsl:value-of select="gzzxid"/>
              </xsl:element>
              <xsl:element name ="ccxh">
                <xsl:value-of select="ccxh"/>
              </xsl:element>
              <xsl:element name ="gxh">
                <xsl:value-of select="gxh"/>
              </xsl:element>
              <xsl:element name ="pk_produce">
                <xsl:value-of select="pk_produce"/>
              </xsl:element>
              <xsl:element name ="ksrq">
                <xsl:value-of select="ksrq"/>
              </xsl:element>
              <xsl:element name ="kssj">
                <xsl:value-of select="kssj"/>
              </xsl:element>
              <xsl:element name ="jsrq">
                <xsl:value-of select="jsrq"/>
              </xsl:element>
              <xsl:element name ="jssj">
                <xsl:value-of select="jssj"/>
              </xsl:element>
              <xsl:element name ="hgsl">
                <xsl:value-of select="hgsl"/>
              </xsl:element>
              <xsl:element name ="fhgsl">
                <xsl:value-of select="fhgsl"/>
              </xsl:element>
              <xsl:element name ="sflfcp">
                <xsl:value-of select="sflfcp"/>
              </xsl:element>
              <xsl:element name ="sffsgp">
                <xsl:value-of select="sffsgp"/>
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
                <xsl:value-of select="freeitemvalue1"/>
              </xsl:element>
              <xsl:element name ="freeitemvalue2">
                <xsl:value-of select="freeitemvalue2"/>
              </xsl:element>
              <xsl:element name ="freeitemvalue3">
                <xsl:value-of select="freeitemvalue3"/>
              </xsl:element>
              <xsl:element name ="freeitemvalue4">
                <xsl:value-of select="freeitemvalue4"/>
              </xsl:element>
              <xsl:element name ="freeitemvalue5">
                <xsl:value-of select="freeitemvalue5"/>
              </xsl:element>
              <xsl:element name ="pk_corp">
                <xsl:value-of select="pk_corp"/>
              </xsl:element>
              <xsl:element name ="gcbm">
                <xsl:value-of select="gcbm"/>
              </xsl:element>
            </xsl:element>
          </xsl:for-each>
        </xsl:element>
      </xsl:element>
    </xsl:element>
  </xsl:template>
</xsl:stylesheet>