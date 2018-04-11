<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes" encoding="gb2312"/>
  <xsl:template match="/">
    <xsl:element name ="ufinterface">
      <xsl:attribute name ="billtype">TS46</xsl:attribute>
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
          <xsl:element name ="cwarehouseid">
            <xsl:value-of select="NewDataSet/M/cwarehouseid"/>
          </xsl:element>
        </xsl:element>
        <xsl:element name ="bill_body">
          <xsl:for-each select="NewDataSet/s1">
            <xsl:element name ="item">
              <xsl:element name ="cwarehouseid">
                <xsl:value-of select ="cwarehouseid"/>
              </xsl:element>
              <xsl:element name ="taccounttime">
                <xsl:value-of select ="taccounttime"/>
              </xsl:element>
              <xsl:element name ="coperatorid">
                <xsl:value-of select="coperatorid"/>
              </xsl:element>
              <xsl:element name ="ccheckstate_bid">
                <xsl:value-of select="ccheckstate_bid"/>
              </xsl:element>
              <xsl:element name ="cworkcenterid">
                <xsl:value-of select="cworkcenterid"/>
              </xsl:element>
              <xsl:element name ="dbizdate">
                <xsl:value-of select="dbizdate"/>
              </xsl:element>
              <xsl:element name ="vbatchcode">
                <xsl:value-of select="vbatchcode"/>
              </xsl:element>
              <xsl:element name ="cinvbasid">
                <xsl:value-of select="cinvbasid"/>
              </xsl:element>
              <xsl:element name ="pk_produce">
                <xsl:value-of select="pk_produce"/>
              </xsl:element>
              <xsl:element name ="ninnum">
                <xsl:value-of select="ninnum"/>
              </xsl:element>
              <xsl:element name ="ninassistnum">
                <xsl:value-of select="ninassistnum"/>
              </xsl:element>
              <xsl:element name ="castunitid">
                <xsl:value-of select="castunitid"/>
              </xsl:element>
              <xsl:element name ="vfree1">
                <xsl:value-of select="vfree1"/>
              </xsl:element>
              <xsl:element name ="vfree2">
                <xsl:value-of select="vfree2"/>
              </xsl:element>
              <xsl:element name ="vfree3">
                <xsl:value-of select="vfree3"/>
              </xsl:element>
              <xsl:element name ="vfree4">
                <xsl:value-of select="vfree4"/>
              </xsl:element>
              <xsl:element name ="vfree5">
                <xsl:value-of select="vfree5"/>
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